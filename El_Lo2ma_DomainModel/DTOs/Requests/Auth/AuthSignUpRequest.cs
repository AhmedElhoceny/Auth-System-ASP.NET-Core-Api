using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.DTOs.Requests.Auth
{
    public class AuthSignUpRequest
    {
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public long  UserType_Id { get; set; }
    }
}
