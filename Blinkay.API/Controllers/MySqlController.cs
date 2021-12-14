using Blinkay.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Blinkay.API.Controllers
{
    [ApiController]
    [Route("blinkay/api/v1/")]
    public class MySqlController : ControllerBase
    {
        private readonly ILogger<MySqlController> _logger;

        private IMySqlService _sqlService;

        public MySqlController(ILogger<MySqlController> logger,
                                IMySqlService SqlService)
        {
            _logger = logger;
            _sqlService = SqlService ?? throw new ArgumentNullException(nameof(SqlService));
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
