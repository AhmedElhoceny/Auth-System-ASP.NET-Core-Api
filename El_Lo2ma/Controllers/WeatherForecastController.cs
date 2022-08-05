using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace El_Lo2ma.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class WeatherForecastController : ControllerBase
    {


        public WeatherForecastController()
        {
            
        }
        [HttpGet("OffAhh")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}