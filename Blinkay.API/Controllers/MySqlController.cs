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

        private readonly IMapperSession _session;

        public MySqlController(ILogger<MySqlController> logger,
                                IMySqlService SqlService,
                                IMapperSession session)
        {
            _logger = logger;
            _session = session;
            _sqlService = SqlService ?? throw new ArgumentNullException(nameof(SqlService));
        }

        [HttpPost("MySql-insertion")]
        public async Task<IActionResult> MySQLInsertion(int iNumRegistries, int iNumThreads)
        {
            return Ok(0);
        }

        [HttpPatch("MySql-select")]
        public async Task<IActionResult> MySQLSelectPlusUpdate(int iNumRegistries, int iNumThreads)
        {
            return Ok(0);
        }

        [HttpPatch("MySql-select-plus-insertion")]
        public async Task<IActionResult> MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads)
        {
            return Ok(0);
        }
    }
}
