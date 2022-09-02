using El_Lo2ma.Constants;
using El_Lo2ma.Constants.LocalizationKeys;
using El_Lo2ma_AccessModel.Constants;
using El_Lo2ma_DomainModel;
using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.JWT;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_DomainModel.DTOs.Responses;
using El_Lo2ma_DomainModel.DTOs.Responses.Auth;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Models.Auth;
using El_Lo2ma_Services.IServices.Auth;
using El_Lo2ma_Services.IServices.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_Services.Services.Auth
{
    public class AuthUserServices : IAuthUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<ShareResource> _localizer;
        private readonly ILogger<ShareResource> _logger;
        private readonly IOptions<JWT> _jwt;
        private readonly IEmailSender _emailSender;

        public AuthUserServices(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IStringLocalizer<ShareResource> localizer, ILogger<ShareResource> logger, IOptions<JWT> jwt, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _localizer = localizer;
            _logger = logger;
            _jwt = jwt;
            _emailSender = emailSender;
        }
        public async Task<Response<AuthUserLogInResponse>> UserLogIn(AuthUserLogInRequest model)
        {
            var SearchedUser = await _unitOfWork.User.GetFirstOrDefaultAsync(filter: x => x.UserName == model.UserName, includeProperties: "RefreshTokenList");
            if (SearchedUser == null || !await _userManager.CheckPasswordAsync(SearchedUser, model.PassWord))
            {
                return new Response<AuthUserLogInResponse>()
                {
                    Message = _localizer[AuthLocalizationKeys.UsernameOrPassWordIsWrong],
                    IsSuccess = false
                };
            }
            var Token = await CreateJwtToken(SearchedUser);
            var RefreshTokenObject = CraeteRefreshToken();

            if (SearchedUser.RefreshTokenList.Count != 0)
            {
                SearchedUser.RefreshTokenList.FirstOrDefault().Token = RefreshTokenObject.Token;
                SearchedUser.RefreshTokenList.FirstOrDefault().ExpirationTime = RefreshTokenObject.ExpirationTime;
                _unitOfWork.User.Update(SearchedUser);
            }
            else
            {
                RefreshTokenObject.UserId = SearchedUser!.Id;
                await _unitOfWork.RefreshTokens.AddAsync(RefreshTokenObject);
            }
            await _unitOfWork.CompleteAsync();

            var ResponseData = new AuthUserLogInResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token),
                RefreshToken = RefreshTokenObject.Token,
                ExpireOn = RefreshTokenObject.ExpirationTime
            };

            return new Response<AuthUserLogInResponse>()
            {
                IsSuccess = true,
                Message = _localizer[AuthLocalizationKeys.Hello, model.UserName],
                Data = ResponseData
            };
        }
        public async Task<Response<AuthUserRegistrationResponse>> UserRegistrationAsync(AuthUserRegistrationRequest model)
        {
            try
            {
                var SearchedUser = await _unitOfWork.User.GetFirstOrDefaultAsync(filter: x => x.UserName == model.UserName || x.Email == model.Email);
                if (SearchedUser != null)
                {
                    return new Response<AuthUserRegistrationResponse>()
                    {
                        Message = _localizer[AuthLocalizationKeys.ThisUserIsExist],
                        IsSuccess = false
                    };
                }

                var SearchedUserType = await _unitOfWork.UserType.GetFirstOrDefaultAsync(filter: x => x.Name == model.UserType);
                if (SearchedUserType == null)
                {
                    _logger.LogCritical(_localizer[AuthLocalizationKeys.UserRegistWithNotExistUserType]);
                    return new Response<AuthUserRegistrationResponse>()
                    {
                        Message = _localizer[AuthLocalizationKeys.FailedProcess],
                        IsSuccess = false
                    };
                }

                var UserApp = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    NormalizedEmail = model.Email,
                    EmailConfirmed = true,
                    NormalizedUserName = model.UserName,
                    PhoneNumber = model.Phone,
                    PhoneNumberConfirmed = true,
                    UserType_Id = SearchedUserType!.Id
                };
                var Result = await _userManager.CreateAsync(UserApp, model.PassWord);
                if (Result.Succeeded)
                {
                    var SearchedRole = await _unitOfWork.Role.GetFirstOrDefaultAsync(filter: x => x.Name == model.UserType);
                    if (SearchedRole == null)
                    {
                        _logger.LogCritical(_localizer[AuthLocalizationKeys.UserRegistWithNotExistRole]);
                        return new Response<AuthUserRegistrationResponse>()
                        {
                            Message = _localizer[AuthLocalizationKeys.FailedProcess],
                            IsSuccess = false
                        };
                    }
                    var UserRole = new ApplicationUserRole()
                    {
                        RoleId = SearchedRole.Id,
                        UserId = (await _unitOfWork.User.GetFirstOrDefaultAsync(filter: x => x.UserName == model.UserName)).Id
                    };
                    await _unitOfWork.UserRole.AddAsync(UserRole);

                    await _unitOfWork.CompleteAsync();
                    _logger.LogInformation(_localizer[AuthLocalizationKeys.UserRegisterationSuccessfully, model.UserName]);
                    return new Response<AuthUserRegistrationResponse>()
                    {
                        Message = _localizer[AuthLocalizationKeys.UserSavedSuccessfully],
                        IsSuccess = true
                    };
                }
                else
                {
                    _logger.LogWarning(_localizer[AuthLocalizationKeys.UserRegisterationFailed, model.UserName]);
                    return new Response<AuthUserRegistrationResponse>()
                    {
                        Message = _localizer[AuthLocalizationKeys.FailedProcess],
                        IsSuccess = false
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogCritical(_localizer[AuthLocalizationKeys.Error, ex.Message]);
                return new Response<AuthUserRegistrationResponse>()
                {
                    Message = _localizer[AuthLocalizationKeys.FailedProcess],
                    IsSuccess = false,
                    Errors = new[] { ex.Message }
                };
            }
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var UserData = await _unitOfWork.User.GetFirstOrDefaultAsync(filter: y => y.Id == user.Id, includeProperties: "UserRoles,UserRoles.Role,UserType");

            var RolesList = new List<Claim>();
            RolesList.AddRange(UserData.UserRoles.Select(x => new Claim("roles", x.Role.Name)));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id),
            }
            .Union(RolesList);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Value.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Value.Issuer,
                claims: claims,
                expires: UserData.UserType != null ? DateTime.UtcNow.AddHours(UserData.UserType.ExpirationTime) : DateTime.UtcNow.AddHours(8),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        private RefreshToken CraeteRefreshToken()
        {
            var RenderNumber = new byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(RenderNumber);
            return new RefreshToken()
            {
                ExpirationTime = DateTime.UtcNow.AddHours(8),
                Token = Convert.ToBase64String(RenderNumber)
            };
        }
        public async Task<Response<AuthUserLogInResponse>> RefreshToken(string? RefreshToken)
        {
            try
            {
                if (RefreshToken == null)
                    return new Response<AuthUserLogInResponse>() { IsSuccess = false };
                var SearchedRefreshTokenItem = await _unitOfWork.RefreshTokens.GetFirstOrDefaultAsync(x => x.Token == RefreshToken, includeProperties: "User");
                if (SearchedRefreshTokenItem == null || SearchedRefreshTokenItem.ExpirationTime < DateTime.UtcNow)
                {
                    return new Response<AuthUserLogInResponse>()
                    {
                        IsSuccess = false,
                        Message = _localizer[AuthLocalizationKeys.FailedProcess]
                    };
                }

                var SearchedUser = SearchedRefreshTokenItem.User;


                var NewToken = await CreateJwtToken(SearchedUser);

                var NewRefreshToken = CraeteRefreshToken();
                SearchedRefreshTokenItem.Token = NewRefreshToken.Token;
                SearchedRefreshTokenItem.ExpirationTime = NewRefreshToken.ExpirationTime;
                _unitOfWork.RefreshTokens.Update(SearchedRefreshTokenItem);
                await _unitOfWork.CompleteAsync();

                return new Response<AuthUserLogInResponse>()
                {
                    Data = new AuthUserLogInResponse() { RefreshToken = NewRefreshToken.Token, ExpireOn = NewRefreshToken.ExpirationTime, Token = new JwtSecurityTokenHandler().WriteToken(NewToken) },
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response<AuthUserLogInResponse>()
                {
                    Errors = new[] { ex.Message },
                    IsSuccess = false,
                    Message = _localizer[AuthLocalizationKeys.Error]
                };
            }
        }
        public async Task<Response<string>> RemoveUser(string userId)
        {
            try
            {
                var user = await _unitOfWork.User.GetFirstOrDefaultAsync(filter: i => i.Id == userId);
                await _unitOfWork.User.Remove(user);
                await _unitOfWork.CompleteAsync();
                return new Response<string>()
                {
                    Data = _localizer[AuthLocalizationKeys.Deleted],
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    Errors = new[] { ex.Message },
                    IsSuccess = false,
                    Message = _localizer[AuthLocalizationKeys.Error]
                };
            }
        }
        public async Task<Response<AuthUserUpdateRequest>> UpdateUser(AuthUserUpdateRequest model, string userId)
        {
            try
            {
                var user = await _unitOfWork.User.GetFirstOrDefaultAsync(filter: i => i.Id == userId);

                user.UserName = model.UserName;
                user.PhoneNumber = model.Phone;
                user.Email = model.Email;
                user.PasswordHash = model.PassWord;

                _unitOfWork.User.Update(user);
                await _unitOfWork.CompleteAsync();

                return new Response<AuthUserUpdateRequest>()
                {
                    Data = model,
                    IsSuccess = true,
                    IsUpdated = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new Response<AuthUserUpdateRequest>()
                {
                    Message = _localizer[AuthLocalizationKeys.Error],
                    Errors = new[] { ex.Message }
                };
            }

        }
        public async Task<Response<List<AuthListOfUsersResponse>>> ListOfUsers()
        {
           try 
           {
                var SearchedData = (await _unitOfWork.User.GetSpecificSelectAsync( filter : x => true,select:x => new AuthListOfUsersResponse() { UserId = x.Id,UserName = x.UserName})).ToList();

                return new Response<List<AuthListOfUsersResponse>>()
                {
                    Data = SearchedData,
                    IsSuccess = true

                };
           }
           catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new Response<List<AuthListOfUsersResponse>>()
                {
                    Message = _localizer[AuthLocalizationKeys.Error],
                    Errors = new[] { ex.Message }
                };
            }
        }
        public async Task<Response<List<SelectListIdString>>> ListOfRoles()
        {
            try
            {
                var Data = (await _unitOfWork.Role.GetSpecificSelectAsync(filter: x => true, select: x => new SelectListIdString()
                {
                    Id = x.Id,
                    Name = x.Name
                })).ToList();
                return new Response<List<SelectListIdString>>()
                {
                    Data = Data,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response<List<SelectListIdString>>()
                {
                    Message = _localizer[AuthLocalizationKeys.Error],
                    Errors = new[] { ex.Message }
                };
            }
        }
        public async Task<Response<string>> SwitchUserActivation(string userId )
        {
           try
           {
            var user = (await _unitOfWork.User.GetFirstOrDefaultAsync(filter: x => x.Id == userId));
            user.IsActive = !user.IsActive;
            _unitOfWork.User.Update(user);
            await _unitOfWork.CompleteAsync();
                return new Response<string>()
                {
                    Message = user.IsActive ? _localizer[AuthLocalizationKeys.Activated] : _localizer[AuthLocalizationKeys.DeActivated],
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    Message = _localizer[AuthLocalizationKeys.Error],
                    IsSuccess = false,
                    Errors = new[] { ex.Message }
                };
            }
        }
        public async Task<Response<string>> ForgetPassWord(string userId)
        {
            try
            {
                var searchedUser = await _unitOfWork.User.GetFirstOrDefaultAsync(filter: x => x.Id == userId);
                var verificationCode = CreateRandomCode(8);
                await _unitOfWork.AuthCode.AddAsync(new AuthCode() { code = verificationCode, UserId = searchedUser.Id, IsActive = true });
                await _emailSender.SendEmailAsync(searchedUser.Email, Messages.ApplicationName, Messages.VerificationMessage);
                return new Response<string>()
                {
                    Message = _localizer[AuthLocalizationKeys.Done],
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(_localizer[AuthLocalizationKeys.Error, ex.Message]);
                return new Response<string>()
                {
                    Message = _localizer[AuthLocalizationKeys.Error],
                    Errors = new[] { ex.Message },
                    IsSuccess = false
                };
            }
        }
        private string CreateRandomCode(int length)
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
        public async Task<Response<string>> ForgetPassWordPost(string userId, string code)
        {
            var activeUserCode = await _unitOfWork.AuthCode.GetFirstOrDefaultAsync(filter: x => x.UserId == userId && x.IsActive);
            activeUserCode.IsActive = false;
            _unitOfWork.AuthCode.Update(activeUserCode);
            await _unitOfWork.CompleteAsync();
            if (activeUserCode.code != code)
                return new Response<string>()
                {
                    Message = _localizer[AuthLocalizationKeys.FailedProcess],
                    IsSuccess = false
                };
            return new Response<string>()
            {
                Message = _localizer[AuthLocalizationKeys.Done],
                IsSuccess = true
            };
        }
        public async Task<Response<string>> ChangePassWord(string userId, string NewPassWord)
        {
            var searchedUser = await _unitOfWork.User.GetFirstOrDefaultAsync(filter: x => x.Id == userId);
            var UserPassWordToken = await _userManager.GeneratePasswordResetTokenAsync(searchedUser);
            var process = await _userManager.ChangePasswordAsync(searchedUser, UserPassWordToken, NewPassWord);
            if (!process.Succeeded)
                return new Response<string>()
                {
                    Message = _localizer[AuthLocalizationKeys.FailedProcess],
                    IsSuccess = false
                };
            return new Response<string>()
            {
                Message = _localizer[AuthLocalizationKeys.Done],
                IsSuccess = true
            };
        }
    }
}