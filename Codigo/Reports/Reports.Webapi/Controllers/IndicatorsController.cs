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
            try
            {
                IEnumerable<Indicator> indicatros = indicatorLogic.GetAll();
                return Ok(IndicatorModel.ToModel(indicatros));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]IndicatorModel model)
        {
            try
            {
                Indicator indicator = model.ToEntity();
                var indicatorCreated = indicatorLogic.Create(indicator);
                IndicatorModel test = IndicatorModel.ToModel(indicatorCreated);

                return CreatedAtRoute("GetIndicator", new { id = indicatorCreated.Id }, IndicatorModel.ToModel(indicator));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}", Name = "GetIndicator")]
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
                Indicator indicatorUpdated = indicatorLogic.Update(IndicatorModel.ToEntity(model));
                return CreatedAtRoute("GetIndicator", new { id = indicatorUpdated.Id }, IndicatorModel.ToModel(indicatorUpdated));
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
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/GetGreenResult", Name = "GetIndicatorGreenResult")]
        public IActionResult GetGreenResult(Guid id)
        {
            try
            {
                string areaConnectionStr = "Server=.\\SQLEXPRESS;Database=AreaDB;Trusted_Connection=True;MultipleActiveResultSets=True;";
                Indicator indicator = indicatorLogic.Get(id);
                string result = indicatorLogic.GetResult(indicator, Color.Green,areaConnectionStr);

                return Ok(result);
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/GetYellowResult", Name = "GetIndicatorYellowResult")]
        public IActionResult GetYellowResult(Guid id)
        {
            try
            {
                string areaConnectionStr = "Server=.\\SQLEXPRESS;Database=AreaDB;Trusted_Connection=True;MultipleActiveResultSets=True;";
                Indicator indicator = indicatorLogic.Get(id);
                string result = indicatorLogic.GetResult(indicator, Color.Yellow, areaConnectionStr);

                return Ok(result);
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/GetRedResult", Name = "GetIndicatorRedResult")]
        public IActionResult GetRedResult(Guid id)
        {
            try
            {
                string areaConnectionStr = "Server=.\\SQLEXPRESS;Database=AreaDB;Trusted_Connection=True;MultipleActiveResultSets=True;";
                Indicator indicator = indicatorLogic.Get(id);
                string result = indicatorLogic.GetResult(indicator, Color.Red, areaConnectionStr);

                return Ok(result);
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
