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
    public class IndicatorsController : ControllerBase
    {
        private IIndicatorLogic indicatorLogic;

        public IndicatorsController(IIndicatorLogic indicatorLogic) : base()
        {
            this.indicatorLogic = indicatorLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Indicator> indicatros = indicatorLogic.GetAll();
            return Ok(IndicatorModel.ToModel(indicatros));
        }

        [HttpPost]
        public IActionResult Post([FromBody]IndicatorModel model)
        {
            try
            {
                Indicator indicator = IndicatorModel.ToEntity(model);
                indicatorLogic.Create(indicator);
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
                var indicator = indicatorLogic.Get(id);
                return Ok(IndicatorModel.ToModel(indicator));

            }
            catch (BusinessLogicInterfaceException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]IndicatorModel model)
        {
            try
            {
                model.Id = id;
                indicatorLogic.Update(IndicatorModel.ToEntity(model));
                return Ok();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, [FromBody]IndicatorModel model)
        {
            try
            {
                model.Id = id;
                indicatorLogic.Remove(IndicatorModel.ToEntity(model));
                return Ok();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
