using El_Lo2ma.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace El_Lo2ma.Areas.Auth
{
    [Area(Modules.Auth)]
    [ApiController]
    [ApiExplorerSettings(GroupName = Modules.Auth)]
    public class AuthController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost(Routes.SignUp)]
        public async Task<IActionResult> SignUp()
        {

            return Ok();
        }
    }
}
