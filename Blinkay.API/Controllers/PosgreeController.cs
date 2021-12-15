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
                                  IMapperSessionPG session)
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
                _logger.LogError($"Exception ocurred during MySql insertion operation {error.Message}");
                return BadRequest();
            }
        }

        [HttpPatch("pg-select")]
        public async Task<IActionResult> PGSelectPlusUpdate(int iNumRegistries, int iNumThreads)
        {
            try
            {

                return Ok(0);
            }
            catch
            {
                // log exception here
                return BadRequest();
            }
            finally
            {
            }
        }

        [HttpPatch("pg-select-plus-insertion")]
        public async Task<IActionResult> PGSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads)
        {
            try
            {

                return Ok(0);
            }
            catch
            {
                // log exception here
                return BadRequest();
            }
            finally
            {
            }
        }
    }
}
