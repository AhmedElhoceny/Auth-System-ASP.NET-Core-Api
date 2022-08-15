using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_AccessModel.Extensions
{
    public static class GetContexxtUserData
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("userId");
        }
    }
}
