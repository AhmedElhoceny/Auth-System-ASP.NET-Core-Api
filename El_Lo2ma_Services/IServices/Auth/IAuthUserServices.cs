using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_DomainModel.DTOs.Responses;
using El_Lo2ma_DomainModel.DTOs.Responses.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_Services.IServices.Auth
{
    public interface IAuthUserServices
    {
        Task<Response<AuthUserRegistrationResponse>> UserRegistrationAsync(AuthUserRegistrationRequest model);
        Task<Response<AuthUserLogInResponse>> UserLogIn(AuthUserLogInRequest model);
        Task<Response<AuthUserLogInResponse>> RefreshToken(string? RefreshToken);
        Task<Response<string>> RemoveUser(string userId);
        Task<Response<AuthUserUpdateRequest>> UpdateUser(AuthUserUpdateRequest model, string userId);
        Task<Response<List<AuthListOfUsersResponse>>> ListOfUsers();
        Task<Response<List<SelectListIdString>>> ListOfRoles();
        Task<Response<string>> SwitchUserActivation(string userId);
        Task<Response<string>> ForgetPassWord(string userId);
        Task<Response<string>> ForgetPassWordPost(string userId , string code);
        Task<Response<string>> ChangePassWord(string userId,string NewPassWord);
    }
}
