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


        public ManagersController(IUserLogic userLogic, IAreaLogic areaLogic) : base()
        {
            this.userLogic = userLogic;
            this.areaLogic = areaLogic;
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

        private List<IndicatorConfig> GetCustomIndicators(Guid managerId, Guid areaId)
        {
            List<IndicatorConfig> iConfigs = userLogic.GetIndicatorConfigs(managerId, areaId).ToList();
            List<Indicator> areaIndicators = areaLogic.Get(areaId).Indicators.ToList();
            foreach (Indicator indicator in areaIndicators)
            {
                if (!iConfigs.Exists(ic => ic.Indicator.Id == indicator.Id))
                {
                    iConfigs.Add(new IndicatorConfig()
                    {
                        Indicator = indicator,
                        IndicatorId = indicator.Id,
                        CustomName = indicator.Name,
                    });
                }
            }
            return iConfigs;
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

    }

}
