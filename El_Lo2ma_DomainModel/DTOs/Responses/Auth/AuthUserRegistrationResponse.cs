using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.DTOs.Responses.Auth
{
    public class AuthUserRegistrationResponse : AuthUserRegistrationRequest
    {
        public string UserId { get; set; }
    }
}
