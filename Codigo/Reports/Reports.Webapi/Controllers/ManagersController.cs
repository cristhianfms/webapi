using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Webapi.Models.ManagerIndicators;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
using System.Linq;



namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class ManagersController : ControllerBase
    {
        private IUserLogic userLogic;
        private IAreaLogic areaLogic;
        private IIndicatorLogic indicatorLogic;


        public ManagersController(IUserLogic userLogic, IAreaLogic areaLogic,
            IIndicatorLogic indicatorLogic) : base()
        {
            this.userLogic = userLogic;
            this.areaLogic = areaLogic;
            this.indicatorLogic = indicatorLogic;
        }

        [HttpGet("{id}/Areas", Name = "GetAreas")]
        public IActionResult Get(Guid id)
        {
            try
            {
                IEnumerable<Area> areas = userLogic.GetManagedAreas(id);
                IEnumerable<ManagerAreaModel> areaModels = areas
                    .Select(a =>
                    {
                        var ret = ManagerAreaModel.ToModel(a);
                        List<IndicatorConfig> indicatorConfigs = GetCustomIndicators(id, a.Id);
                        ret.Indicators = CustomIndicatorGetModel.ToModel(indicatorConfigs).ToList();
                        return ret;
                    });
                return Ok(areaModels);
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/Indicators", Name = "GetIndicatorsByArea")]
        public IActionResult Get(Guid id, [FromQuery] Guid area_id)
        {
            try
            {
                List<IndicatorConfig> indicatorConfigs = GetCustomIndicators(id, area_id);
                IEnumerable<CustomIndicatorGetModel> customIndicatorModels = indicatorConfigs
                    .Select(ic => CustomIndicatorGetModel.ToModel(ic));
                return Ok(customIndicatorModels);
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/Indicators", Name = "UpdateIndicatorConfig")]
        public IActionResult Put(Guid id, [FromBody]CustomIndicatorUpdateModel model)
        {
            try
            {
                Guid indicatorId = model.Id;
                bool visible = model.Visible;
                int pos = model.Position;
                string customName = model.CustomName;
                userLogic.SetIndicatorCustomName(id, indicatorId, customName);
                userLogic.SetIndicatorPosition(id, indicatorId, pos);
                userLogic.SetIndicatorVisible(id, indicatorId, visible);

                IndicatorConfig iConfig = userLogic.GetIndicatorConfig(id, indicatorId);
                
                return CreatedAtRoute("Get", new { id = indicatorId }, CustomIndicatorGetModel.ToModel(iConfig));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/IndicatorsSummary", Name = "GetIndicatorsSummary")]
        public IActionResult GetIndicatorsSummary(Guid id)
        {
            try
            {
                IEnumerable<Area> areas = userLogic.GetManagedAreas(id);
                IEnumerable<IndicatorSummaryModel> summaryModels = areas
                    .Select(a =>
                    {
                        return new IndicatorSummaryModel()
                        {
                            AreaId = a.Id,
                            AreaName = a.Name,
                            GreenIndicators = indicatorLogic.CountGreenIndicators(id, a.Id),
                            YellowIndicators = indicatorLogic.CountYellowIndicators(id, a.Id),
                            RedIndicators = indicatorLogic.CountRedIndicators(id, a.Id),
                            VisibleIndicators = indicatorLogic.CountVisibleIndicators(id, a.Id)
                        };
                    });

                return Ok(summaryModels);
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        private List<IndicatorConfig> GetCustomIndicators(Guid managerId, Guid areaId)
        {
            return indicatorLogic.GetCustomIndicators(managerId, areaId).ToList();
        }
    }

}
