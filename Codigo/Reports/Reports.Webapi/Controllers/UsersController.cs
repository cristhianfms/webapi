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
        private IIndicatorLogic indicatorLogic;

        public UsersController(IUserLogic userLogic,
            IIndicatorLogic indicatorLogic) : base()
        {
            this.userLogic = userLogic;
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
                var user = userLogic.Update(id, UserModel.ToEntity(model));
                if(model.Role == 'M')
                {
                    userLogic.SetManagerRole(id);
                }
                if (model.Role == 'A')
                {
                    userLogic.SetAdminRole(id);
                }
                user = userLogic.Get(id);
                return CreatedAtRoute("Get", new { id = user.Id }, UserModel.ToModel(user));
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
                userLogic.Remove(id);
                return NoContent();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
