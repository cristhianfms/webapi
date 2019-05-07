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
            IEnumerable<Area> areas = areaLogic.GetAll();
            return Ok(AreaModel.ToModel(areas));
        }


        [HttpPost]
        public IActionResult Post([FromBody]AreaModel model)
        {
            try
            {
                Area area = AreaModel.ToEntity(model);
                areaLogic.CreateArea(AreaModel.ToEntity(model));
                return Ok();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
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
                areaLogic.UpdateArea(AreaModel.ToEntity(model));
                return Ok();
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
                return Ok();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
