using Blinkay.Domain.Interfaces;
using Blinkay.Domain.Services;
using Blinkay.Infrastructure.Entities;
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
                               IMapperSession session)
        {
            _logger = logger;
            _sqlService = new MySqlService(session);
        }

        [HttpPost("MySql-insertion")]
        public async Task<IActionResult> MySQLInsertion(int iNumRegistries, int iNumThreads)
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

        [HttpPatch("MySql-select")]
        public async Task<IActionResult> MySQLSelectPlusUpdate(int iNumRegistries, int iNumThreads)
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

        [HttpPatch("MySql-select-plus-insertion")]
        public async Task<IActionResult> MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads)
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
