using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Webapi.Filters;
using Reports.Logger.Interface;
using Reports.Logger.Domain;
using Reports.Domain;

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

        //[ProtectFilter("Admin")]
        [HttpGet("ManagersMoreLogged")]
        public IActionResult ManagersMoreLogged()
        {
            try {
                IEnumerable<string> userNames = logger.ManagersMoreLogged();
                return Ok(userNames);
            }
            catch (ILoggerException e)
            {
                return BadRequest("something went wrong when consulting database");
            }
        }


        //[ProtectFilter("Admin")]
        [HttpGet("IndicatorsMoreHidden")]
        public IActionResult IndicatorsMoreHidden()
        {
            try
            {
                IEnumerable<Indicator> indicators = logger.IndicatorsMoreHidden();
                IEnumerable<IndicatorReportModel> indicatorModels = indicators
                    .Select(i => IndicatorReportModel.ToModel(i));
                return Ok(indicatorModels);
            }
            catch (ILoggerException e)
            {
                return BadRequest("something went wrong when consulting database");
            }
        }


        //[ProtectFilter("Admin")]
        [HttpGet("ActionLogsByDate")]
        public IActionResult ActionLogsByDate([FromQuery] string date_from, [FromQuery] string date_to)
        {
            try
            {
                DateTime from = DateTime.ParseExact(date_from, "ddMMyyyyHHmmss",null);
                DateTime to = DateTime.ParseExact(date_to, "ddMMyyyyHHmmss",null);
                IEnumerable<Log> logs = logger.ActionLogsByDate(from, to);
                return Ok(logs);
            }
            catch (ILoggerException e)
            {
                return BadRequest("Error: " + e.Message);
            }
            catch(System.FormatException e)
            {
                return BadRequest("Date format is not ok");
            }
        }

    }
}
