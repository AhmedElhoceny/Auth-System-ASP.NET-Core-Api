using El_Lo2ma.Constants.LocalizationKeys;
using El_Lo2ma_AccessModel.Constants;
using El_Lo2ma_DomainModel;
using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.JWT;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_DomainModel.DTOs.Responses;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Models.Auth;
using El_Lo2ma_Services.IServices.Auth;
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

        public AuthUserServices(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IStringLocalizer<ShareResource> localizer, ILogger<ShareResource> logger, IOptions<JWT> jwt)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _localizer = localizer;
            _logger = logger;
            _jwt = jwt;
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
            var Token =await CreateJwtToken(SearchedUser);
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

        public async void RemoveUser(string userId)
        {
            var user = await _unitOfWork.User.GetFirstOrDefaultAsync(filter: i => i.Id == userId);
            await _unitOfWork.User.Remove(user);
            await _unitOfWork.CompleteAsync();


        }
    }
}
