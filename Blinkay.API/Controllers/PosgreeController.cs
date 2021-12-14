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
    public class PosgreeController : ControllerBase
    {
        private readonly ILogger<PosgreeController> _logger;

        private IPosgreeService _posgreeService;

        private readonly IMapperSession _session;

        public PosgreeController(ILogger<PosgreeController> logger,
                                  IPosgreeService posgreeService,
                                  IMapperSession session)
        {
            _logger = logger;
            _session = session;
            _posgreeService = posgreeService ?? throw new ArgumentNullException(nameof(posgreeService));
        }

        [HttpPost("pg-insertion")]
        public async Task<IActionResult> PGInsertion(int iNumRegistries, int iNumThreads)
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

        [HttpPatch("pg-select")]
        public async Task<IActionResult> PGSelectPlusUpdate(int iNumRegistries, int iNumThreads)
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

        [HttpPatch("pg-select-plus-insertion")]
        public async Task<IActionResult> PGSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads)
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
