using Blinkay.API.DTOs;
using Blinkay.Domain.Interfaces;
using Blinkay.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Blinkay.API.Controllers
{
    [ApiController]
    [Route("blinkay/api/v1/")]
    public class MySqlController : ControllerBase
    {
        private readonly ILogger<MySqlController> _logger;

        private IMySqlService _mySqlService;

        public MySqlController(ILogger<MySqlController> logger,
                               IMapperSession session)
        {
            _logger = logger;
            _mySqlService = new MySqlService(session);
        }

        [HttpPost("MySql-insertion")]
        public async Task<IActionResult> MySQLInsertion([FromHeader] AddEntityrequest request)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < request.NumThreads; ++i)
                {
                    await Task.Run(() => this._mySqlService.MySQLInsertion(request.NumRegistres));
                }
                sw.Stop();
                return Ok(sw.ElapsedMilliseconds);
            }
            catch (Exception error)
            {
                // log exception here
                _logger.LogError($"Exception ocurred during MySql insertion operation {error.Message}");
                return BadRequest();
            }
        }

        [HttpPatch("MySql-select")]
        public async Task<IActionResult> MySQLSelectPlusUpdate(int iNumRegistries, int iNumThreads)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sw.Stop();

                return Ok(0);
            }
            catch (Exception error)
            {
                // log exception here
                _logger.LogError($"Exception ocurred during MySql select plus update operation {error.Message}");
                return BadRequest();
            }
            finally
            {
            }
        }

        [HttpPatch("MySql-select-plus-insertion")]
        public async Task<IActionResult> MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sw.Stop();
                return Ok(0);
            }
            catch (Exception error)
            {
                // log exception here
                _logger.LogError($"Exception ocurred during MySql select plus update plus insertion operation {error.Message}");
                return BadRequest();
            }
            finally
            {
            }
        }
    }
}
