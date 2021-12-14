using Blinkay.Domain.Interfaces;
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
            try
            {
                _session.BeginTransaction();

                await _session.Save(new User());
                await _session.Commit();

                return Ok(0);
            }
            catch
            {
                // log exception here
                await _session.Rollback();
                return BadRequest();
            }
            finally
            {
                _session.CloseTransaction();
            }
        }

        [HttpPatch("MySql-select")]
        public async Task<IActionResult> MySQLSelectPlusUpdate(int iNumRegistries, int iNumThreads)
        {
            try
            {
                _session.BeginTransaction();

                await _session.Save(new User());
                await _session.Commit();

                return Ok(0);
            }
            catch
            {
                // log exception here
                await _session.Rollback();
                return BadRequest();
            }
            finally
            {
                _session.CloseTransaction();
            }
        }

        [HttpPatch("MySql-select-plus-insertion")]
        public async Task<IActionResult> MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads)
        {
            try
            {
                _session.BeginTransaction();

                await _session.Save(new User());
                await _session.Commit();

                return Ok(0);
            }
            catch
            {
                // log exception here
                await _session.Rollback();
                return BadRequest();
            }
            finally
            {
                _session.CloseTransaction();
            }
        }
    }
}
