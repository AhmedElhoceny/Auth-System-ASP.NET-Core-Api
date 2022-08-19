using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_DomainModel.DTOs.Responses;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Models.Auth;
using El_Lo2ma_Services.IServices.Auth;
using Microsoft.AspNetCore.Identity;
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

        public AuthUserServices(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Response<AuthUserRegistrationResponse>> UserRegistration(AuthUserRegistrationRequest model)
        {
            return new Response<AuthUserRegistrationResponse>();
            //try
            //{
            //    var UserApp = new ApplicationUser()
            //    {
            //        UserName = model.UserName,
            //        Email = model.Email,
            //        NormalizedEmail = model.Email,
            //        EmailConfirmed = true,
            //        NormalizedUserName = model.UserName,
            //        PhoneNumber = model.Phone,
            //        PhoneNumberConfirmed = true
            //    };
            //    var Result = await _userManager.CreateAsync(UserApp,model.PassWord);
            //    if (Result.Succeeded)
            //    {
                    
            //    }

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
    }
}
