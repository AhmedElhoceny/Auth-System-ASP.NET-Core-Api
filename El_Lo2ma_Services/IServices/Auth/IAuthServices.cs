using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_Services.IServices.Auth
{
    public interface IAuthServices
    {
        Task<Response<string>> UserRegist(AuthSignUpRequest model);
    }
}
