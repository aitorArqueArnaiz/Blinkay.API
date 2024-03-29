﻿using Blinkay.API.DTOs;
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
        public async Task<IActionResult> MySQLInsertion([FromBody] AddEntityRequest request)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < request.NumThreads; i++)
                {
                    await Task.Factory.StartNew(() => this._mySqlService.MySQLInsertion(request.NumRegistres));
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

        [HttpPatch("MySql-select-plus-update")]
        public async Task<IActionResult> MySQLSelectPlusUpdate([FromBody] SelectPlusUpdateRequest request)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < request.NumThreads; i++)
                {
                    await Task.Factory.StartNew(() => this._mySqlService.MySQLSelectPlusUpdate(request.NumRegistres));
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
                _logger.LogError($"Exception ocurred during MySql insertion operation {error.Message}");
                return BadRequest();
            }
        }

        [HttpPatch("MySql-select-plus-update-plus-insertion")]
        public async Task<IActionResult> MySQLSelectPlusUpdatePlusInsertion([FromBody] SelectPlusUpdatePlusInsertionRequest request)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < request.NumThreads; i++)
                {
                    await Task.Factory.StartNew(() => this._mySqlService.MySQLSelectPlusUpdatePlusInsertion(request.NumRegistres));
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
                _logger.LogError($"Exception ocurred during MySql select plus update plus insertion operation {error.Message}");
                return BadRequest();
            }
        }
    }
}
