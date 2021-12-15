using Blinkay.API.DTOs;
using Blinkay.Domain.Interfaces;
using Blinkay.Domain.Services;
using Blinkay.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
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
                                  ApplicationContext session)
        {
            _logger = logger;
            _posgreeService = new PosgreeService(session);
        }

        [HttpPost("pg-insertion")]
        public async Task<IActionResult> PGInsertion([FromBody] AddEntityRequest request)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < request.NumThreads; i++)
                {
                    await Task.Factory.StartNew(() => this._posgreeService.PGInsertion(request.NumRegistres));
                }
                sw.Stop();

                var response = new AddEntityResponse()
                {
                    TimeOfExecution = sw.ElapsedMilliseconds
                };
                return Ok(response);
            }
            catch (Exception error)
            {
                // log exception here
                _logger.LogError($"Exception ocurred during Postgre insertion operation {error.Message}");
                return BadRequest();
            }
        }

        [HttpPatch("pg-select-plus-update")]
        public async Task<IActionResult> PGSelectPlusUpdate([FromBody] SelectPlusUpdateRequest request)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < request.NumThreads; i++)
                {
                    await Task.Factory.StartNew(() => this._posgreeService.PGSelectPlusUpdate(request.NumRegistres));
                }
                sw.Stop();

                var response = new SelectPlusUpdateResponse()
                {
                    TimeOfExecution = sw.ElapsedMilliseconds
                };
                return Ok(response);
            }
            catch (Exception error)
            {
                // log exception here
                _logger.LogError($"Exception ocurred during Postgre insertion operation {error.Message}");
                return BadRequest();
            }
        }

        [HttpPatch("pg-select-plus-update-plus-insertion")]
        public async Task<IActionResult> PGSelectPlusUpdatePlusInsertion([FromBody] SelectPlusUpdatePlusInsertionRequest request)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < request.NumThreads; i++)
                {
                    await Task.Factory.StartNew(() => this._posgreeService.PGSelectPlusUpdatePlusInsertion(request.NumRegistres));
                }
                sw.Stop();

                var response = new SelectPlusUpdatePlusInsertionResponse()
                {
                    TimeOfExecution = sw.ElapsedMilliseconds
                };
                return Ok(response);
            }
            catch (Exception error)
            {
                // log exception here
                _logger.LogError($"Exception ocurred during Postgre select plus update plus insertion operation {error.Message}");
                return BadRequest();
            }
        }
    }
}
