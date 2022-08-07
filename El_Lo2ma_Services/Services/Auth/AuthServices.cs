using El_Lo2ma.Constants;
using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Models;
using El_Lo2ma_Services.IServices.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_Services.Services.Auth
{
    public class AuthServices : IAuthServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public AuthServices(IUnitOfWork UnitOfWork , UserManager<ApplicationUser> userManager)
        {
            _UnitOfWork = UnitOfWork;
            _userManager = userManager;
            //_roleManager = roleManager;
        }
        public async Task<Response<string>> UserRegist(AuthSignUpRequest model)
        {

            try
            {
                if (await _UnitOfWork.Users.ExistAsync(filter: x => x.UserName == model.UserName || x.Email == model.Email))
                {
                    return new Response<string>()
                    {
                        Message = Messages.IsExist,
                        IsSuccess = false
                    };
                }
                var UserApp = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    IsActive = true,
                    PhoneNumber = model.PhoneNumber,
                    Rate = 0,
                    UserType_Id = model.UserType_Id
                };
                var SavingResult = await _userManager.CreateAsync(UserApp, model.PassWord);
                if (SavingResult.Succeeded)
                {
                    return new Response<string>()
                    {
                        Message = Messages.Done,
                        IsSuccess = true
                    };
                }
                else
                {
                    return new Response<string>()
                    {
                        Message = Messages.Failed,
                        IsSuccess = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    Message = Messages.Failed,
                    IsSuccess = false,
                    Errors = new[] { ex.Message }
                };
            }
        }
    }
}
