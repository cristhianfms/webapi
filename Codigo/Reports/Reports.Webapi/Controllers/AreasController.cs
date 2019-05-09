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

        public AreasController(IAreaLogic areaLogic) : base()
        {
            this.areaLogic = areaLogic;
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
        public IActionResult Delete(Guid id, [FromBody]AreaModel model)
        {
            try
            {
                model.Id = id;
                areaLogic.RemoveArea(AreaModel.ToEntity(model));
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
                areaLogic.RemoveManager(id, manager.AreaId);
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
                return Ok(AreaIndicatorModel.ToModel(indicators));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost("{id}/Indicators")]
        public IActionResult AddIndicator(Guid id, [FromBody]AreaIndicatorModel indicator)
        {
            try
            {
                areaLogic.AddIndicator(id, indicator.IndicatorId);
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}/Indicators")]
        public IActionResult DeleteIndicator(Guid id, [FromBody]AreaIndicatorModel indicator)
        {
            try
            {
                areaLogic.RemoveManager(id, indicator.IndicatorId);
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
