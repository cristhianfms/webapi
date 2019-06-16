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
    public class CheckIndicatorController : ControllerBase
    {
        private IAreaLogic areaLogic;
        private IIndicatorLogic indicatorLogic;

        public CheckIndicatorController(IAreaLogic areaLogic, IIndicatorLogic indicatorLogic) : base()
        {
            this.areaLogic = areaLogic;
            this.indicatorLogic = indicatorLogic;
        }


        [HttpPost]
        public IActionResult Post([FromBody]IndicatorCheckModel model)
        {
            try
            {
                Indicator indicator = model.ToEntity();
                String conStr = areaLogic.Get(model.AreaId).ConnectionString;

                IndicatorResultsModel modelToReturn = new IndicatorResultsModel();

                if (indicator.GreenCondition != null)
                {
                    modelToReturn.GreenConditionOk = indicatorLogic.CheckConditionEval(indicator.GreenCondition, conStr);
                    modelToReturn.GreenConditionResult = indicatorLogic.GetConditionResult(indicator.GreenCondition, conStr);
                }

                if (indicator.YellowCondition != null)
                {
                    modelToReturn.YellowConditionOk = indicatorLogic.CheckConditionEval(indicator.YellowCondition, conStr);
                    modelToReturn.YellowConditionResult = indicatorLogic.GetConditionResult(indicator.YellowCondition, conStr);
                }

                if (indicator.RedCondition != null)
                {
                    modelToReturn.RedConditionOk = indicatorLogic.CheckConditionEval(indicator.RedCondition, conStr);
                    modelToReturn.RedConditionResult = indicatorLogic.GetConditionResult(indicator.RedCondition, conStr);
                }

                return Ok(modelToReturn);
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        


    }
}
