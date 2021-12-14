using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blinkay.API.Controllers
{
    [ApiController]
    [Route("blinkay/api/v1/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
