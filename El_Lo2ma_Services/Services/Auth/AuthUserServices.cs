using El_Lo2ma.Constants.LocalizationKeys;
using El_Lo2ma_AccessModel.Constants;
using El_Lo2ma_DomainModel;
using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_DomainModel.DTOs.Responses;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Models.Auth;
using El_Lo2ma_Services.IServices.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public AuthUserServices(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager,IStringLocalizer<ShareResource> localizer,ILogger<ShareResource> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _localizer = localizer;
            _logger = logger;
        }

        public async Task<Response<AuthUserRegistrationResponse>> UserRegistration(AuthUserRegistrationRequest model)
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
                var UserApp = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    NormalizedEmail = model.Email,
                    EmailConfirmed = true,
                    NormalizedUserName = model.UserName,
                    PhoneNumber = model.Phone,
                    PhoneNumberConfirmed = true
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
    }
}
