using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Webapi.Filters;
using Reports.Logger.Interface;

namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private ILoggerLogic logger;

        public LogsController(ILoggerLogic logger) : base()
        {
            this.logger = logger;
        }

        [ProtectFilter("Admin")]
        [HttpGet("TopTenLoggers")]
        public IActionResult CheckLogin()
        {
            try {
                return Ok(logger.RankingTopTen());
            }
            catch (Exception e)
            {
                return BadRequest("something went wrong when consulting database");
            }
        }
    }
}
