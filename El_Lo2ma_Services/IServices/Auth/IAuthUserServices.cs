using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_DomainModel.DTOs.Responses;
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
        void RemoveUser(string userId);

    }
}
