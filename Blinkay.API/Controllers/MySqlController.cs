using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blinkay.API.Controllers
{
    [ApiController]
    [Route("blinkay/api/v1/")]
    public class MySqlController : ControllerBase
    {
        private readonly ILogger<MySqlController> _logger;

        public MySqlController(ILogger<MySqlController> logger)
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
