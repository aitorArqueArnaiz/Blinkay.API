﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blinkay.API.Controllers
{
    [ApiController]
    [Route("blinkay/api/v1/")]
    public class PosgreeController : ControllerBase
    {
        private readonly ILogger<PosgreeController> _logger;

        public PosgreeController(ILogger<PosgreeController> logger)
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
