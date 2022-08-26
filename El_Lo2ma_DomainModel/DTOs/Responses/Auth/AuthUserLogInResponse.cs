using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.DTOs.Responses.Auth
{
    public class AuthUserLogInResponse
    {
        public string Token { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
