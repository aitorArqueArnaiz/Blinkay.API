using Blinkay.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Blinkay.API.Controllers
{
    [ApiController]
    [Route("blinkay/api/v1/")]
    public class PosgreeController : ControllerBase
    {
        private readonly ILogger<PosgreeController> _logger;
        private IPosgreeService _posgreeService;

        public PosgreeController(ILogger<PosgreeController> logger,
                                  IPosgreeService posgreeService)
        {
            _logger = logger;
            _posgreeService = posgreeService ?? throw new ArgumentNullException(nameof(posgreeService));
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
