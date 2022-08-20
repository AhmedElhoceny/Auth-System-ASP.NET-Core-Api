using El_Lo2ma.Constants;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_Services.IServices.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace El_Lo2ma.Areas.Auth
{
    [Area(Modules.Auth)]
    [ApiController]
    [ApiExplorerSettings(GroupName = Modules.Auth)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthUserServices _userServices;

        public AuthController(ILogger<AuthController> logger, IAuthUserServices UserServices)
        {
            _logger = logger;
            _userServices = UserServices;
        }
        [AllowAnonymous]
        [HttpPost(Routes.SignUp)]
        public async Task<IActionResult> SignUp([FromBody]AuthUserRegistrationRequest model)
        {
            var Result = await _userServices.UserRegistrationAsync(model);
            if (!Result.IsSuccess)
                return StatusCode(500, Result);
            return StatusCode(200, Result);
        }
        [AllowAnonymous]
        [HttpPost(Routes.LogIn)]
        public async Task<IActionResult> LogIn([FromBody] AuthUserLogInRequest model)
        {
            var Result = await _userServices.UserLogIn(model);

            if (Result.Data != null)
            {
                var CookieOptions = new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = Result.Data.ExpireOn
                };
                Response.Cookies.Append("refreshToken", Result.Data.RefreshToken, CookieOptions);
            }

            if (!Result.IsSuccess)
                return StatusCode(500, Result);
            return StatusCode(200, Result);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Routes.RefreshToken)]
        public async Task<IActionResult> RefreshToken()
        {
            var RefreshToken = Request.Cookies["refreshToken"];
            var Result = await _userServices.RefreshToken(RefreshToken);

            if (Result.Data != null)
            {
                var CookieOptions = new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = Result.Data.ExpireOn
                };
                Response.Cookies.Append("refreshToken", Result.Data.RefreshToken, CookieOptions);
            }

            if (!Result.IsSuccess)
                return StatusCode(500, Result);
            return StatusCode(200, Result);
        }
    }
}
