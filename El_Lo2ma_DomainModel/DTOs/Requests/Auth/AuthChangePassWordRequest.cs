using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.DTOs.Requests.Auth
{
    public class AuthChangePassWordRequest
    {
        public string UserId { get; set; }
        public string NewPassWord { get; set; }
    }
}
