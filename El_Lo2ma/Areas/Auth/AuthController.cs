using El_Lo2ma.Constants;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_Services.IServices.Auth;
using El_Lo2ma_Services.IServices.General;
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


        public AuthController(ILogger<AuthController> logger, IAuthUserServices UserServices )
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(Routes.ListOfUsers)]
        public async Task<IActionResult> ListOfusers()
        {
            var Data = await _userServices.ListOfUsers();
            if (!Data.IsSuccess)
            {
                return StatusCode(500, Data);
            }
            return Ok(Data);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut(Routes.UpdateUser)]
        public async Task<IActionResult> UpdateUser(AuthUserUpdateRequest model, string userId)
        {
            var Data = await _userServices.UpdateUser(model, userId);
            if (!Data.IsSuccess)
            {
                return StatusCode(500, Data);
            }
            return Ok(Data);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete(Routes.RemoveUser)]
        public async Task<IActionResult> RemoveUser(string UserId)
        {
            var Data = await _userServices.RemoveUser(UserId);
            if (!Data.IsSuccess)
            {
                return StatusCode(500, Data);
            }
            return Ok(Data);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(Routes.ListOfRoles)]
        public async Task<IActionResult> ListOfRoles()
        {
            var Data = await _userServices.ListOfRoles();
            if (!Data.IsSuccess)
            {
                return StatusCode(500, Data);
            }
            return Ok(Data);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(Routes.ChangeActivationUser)]
        public async Task<IActionResult> ChangeActivationUser(string userId)
        {
            var Data = await _userServices.SwitchUserActivation(userId);
            if (!Data.IsSuccess)
            {
                return StatusCode(500, Data);
            }
            return Ok(Data);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Routes.ForgetPassWordRequest)]
        public async Task<IActionResult> ForgetPassWordRequest(string userId)
        {
            var data = await _userServices.ForgetPassWord(userId);
            if(!data.IsSuccess)
                return StatusCode(500, data);
            return Ok(data);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Routes.ForgetPassWordPost)]
        public async Task<IActionResult> ForgetPassWordPost(AuthForgetPassWordPostRequest model)
        {
            var data = await _userServices.ForgetPassWordPost(model.UserId , model.Code);
            if (!data.IsSuccess)
                return StatusCode(500, data);
            return Ok(data);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Routes.ChangePassWord)]
        public async Task<IActionResult> ChangePassWord(AuthChangePassWordRequest model)
        {
            var data = await _userServices.ChangePassWord(model.UserId, model.NewPassWord);
            if (!data.IsSuccess)
                return StatusCode(500, data);
            return Ok(data);
        }
    }
}
