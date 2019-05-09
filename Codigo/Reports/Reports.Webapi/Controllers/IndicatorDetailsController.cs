using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
using System.Linq;


namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class IndicatorDetailsController : ControllerBase
    {
        private IIndicatorLogic indicatorLogic;

        public IndicatorDetailsController(IIndicatorLogic indicatorLogic) : base()
        {
            this.indicatorLogic = indicatorLogic;
        }


        [HttpGet("{id}", Name = "GetIndicatorDetail")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var indicator = indicatorLogic.Get(id);
                var indicatorDetailModel = new IndicatorDetailModel()
                {
                    Id = indicator.Id,
                    Color = indicator.Color,
                    IsON = indicator.IsTurnON(),
                    ConditionDetails = ""
                };
                return CreatedAtRoute("GetIndicatorDetail", new { id = indicatorDetailModel.Id }, indicatorDetailModel);
            }

            catch (BusinessLogicInterfaceException e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
