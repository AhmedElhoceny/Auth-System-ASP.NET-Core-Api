using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace El_Lo2ma.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
            
        }
        [HttpPost("")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}