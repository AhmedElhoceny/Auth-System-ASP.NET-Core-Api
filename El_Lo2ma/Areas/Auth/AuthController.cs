using El_Lo2ma.Constants;
using El_Lo2ma_DomainModel.DTOs.Requests.Auth;
using El_Lo2ma_Services.IServices.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace El_Lo2ma.Areas.Auth
{
    [Area(Modules.Auth)]
    [ApiController]
    [ApiExplorerSettings(GroupName = Modules.Auth)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [AllowAnonymous]
        [HttpPost(Routes.SignUp)]
        public async Task<IActionResult> SignUp(AuthSignUpRequest model)
        {
            var Result = await _authServices.UserRegist(model);
            if (!Result.IsSuccess)
            {
                return StatusCode(500, model);
            }
            return Ok(model);
        }
    }
}
