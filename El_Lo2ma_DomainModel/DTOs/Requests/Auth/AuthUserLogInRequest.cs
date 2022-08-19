using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.DTOs.Requests.Auth
{
    public class AuthUserLogInRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
