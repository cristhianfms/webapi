using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;

namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {

        private IAreaLogic areaLogic;
        private IIndicatorLogic indicatorLogic;

        public AreasController(IAreaLogic areaLogic, IIndicatorLogic indicatorLogic) : base()
        {
            this.areaLogic = areaLogic;
            this.indicatorLogic = indicatorLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Area> areas = areaLogic.GetAll();
                return Ok(AreaModel.ToModel(areas));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]AreaModel model)
        {
            try
            {
                var area = areaLogic.CreateArea(AreaModel.ToEntity(model));
                return CreatedAtRoute("GetArea", new { id = area.Id }, AreaModel.ToModel(area));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}", Name = "GetArea")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var area = areaLogic.Get(id);
                return Ok(AreaModel.ToModel(area));

            }
            catch (BusinessLogicInterfaceException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]AreaModel model)
        {
            try
            {
                model.Id = id;
                var area = areaLogic.UpdateArea(AreaModel.ToEntity(model));
                return CreatedAtRoute("GetArea", new { id = area.Id }, AreaModel.ToModel(area));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                areaLogic.RemoveArea(id);
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/Managers")]
        public IActionResult GetManagers(Guid id)
        {
            try
            {
                IEnumerable<User> managers = areaLogic.GetManagers(id);
                return Ok(UserModel.ToModel(managers));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost("{id}/Managers")]
        public IActionResult AddManager(Guid id, [FromBody]AreaManagerModel manager)
        {
            try
            {
                areaLogic.AddManager(id, manager.ManagerId);
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}/Managers")]
        public IActionResult DeleteManager(Guid id, [FromBody]AreaManagerModel manager)
        {
            try
            {
                areaLogic.RemoveManager(id, manager.ManagerId);
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}/Indicators")]
        public IActionResult GetIndicators(Guid id)
        {
            try
            {
                IEnumerable<Indicator> indicators = areaLogic.GetIndicators(id);
                return Ok(IndicatorModel.ToModel(indicators));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost("{id}/Indicators")]
        public IActionResult AddIndicator(Guid id, [FromBody]IndicatorModel model)
        {
            try
            {
                Indicator indicator = model.ToEntity();
                Area area = areaLogic.Get(id);
                indicator.Area = area;

                var indicatorCreated = indicatorLogic.Create(indicator);
                areaLogic.AddIndicator(id, indicatorCreated.Id);
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
