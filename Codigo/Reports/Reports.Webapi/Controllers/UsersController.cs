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
    public class UsersController : ControllerBase
    {
        private IUserLogic userLogic;
        private IIndicatorDisplayLogic indicatorDisplayLogic;
        private IIndicatorLogic indicatorLogic;

        public UsersController(IUserLogic userLogic, IIndicatorDisplayLogic indicatorDisplayLogic,
            IIndicatorLogic indicatorLogic) : base()
        {
            this.userLogic = userLogic;
            this.indicatorDisplayLogic = indicatorDisplayLogic;
            this.indicatorLogic = indicatorLogic;
        }


        [HttpPost]
        public IActionResult Post([FromBody]UserModel model)
        {
            try
            {
                var user = userLogic.Create(UserModel.ToEntity(model));
                return CreatedAtRoute("Get", new { id = user.Id }, UserModel.ToModel(user));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<User> users = userLogic.GetAll();
                return Ok(UserModel.ToModel(users));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var user = userLogic.Get(id);
                return Ok(UserModel.ToModel(user));

            }
            catch (BusinessLogicInterfaceException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]UserModel model)
        {
            try
            {
                model.Id = id;
                var user = userLogic.Update(UserModel.ToEntity(model));
                return CreatedAtRoute("Get", new { id = user.Id }, UserModel.ToModel(user));
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, [FromBody]UserModel model)
        {
            try
            {
                model.Id = id;
                userLogic.Remove(UserModel.ToEntity(model));
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("{id}/display_indicator")]
        [HttpGet]
        public IActionResult GetAllIndicatorByUserId(Guid id)
        {
            try
            {
                IEnumerable<IndicatorDisplay> indicators = indicatorDisplayLogic.GetAllByManagerId(id);
                IEnumerable <IndicatorDisplayModel> indicatorModels = IndicatorDisplayModel.ToModel(indicators);
                indicatorModels.Select(im =>
                {
                    var indicator = indicatorLogic.Get(im.Id);
                    im.IsTurnON = indicator.IsTurnON();
                    return im;
                });
                
                return Ok(indicatorModels);
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}/display_indicator")]
        [HttpPut]
        public IActionResult ModifyIndicatorDisplay(Guid id, [FromBody]IndicatorDisplayModel model)
        {
            try
            {
                model.UserId = id;
                indicatorDisplayLogic.Update(IndicatorDisplayModel.ToEntity(model));
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
