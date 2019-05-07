using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;


namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserLogic userLogic;

        public UsersController(IUserLogic userLogic) : base()
        {
            this.userLogic = userLogic;
        }



        [HttpPost]
        public IActionResult Post([FromBody]UserModel model)
        {
            try
            {
                userLogic.Create(UserModel.ToEntity(model));
                return Ok();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = userLogic.GetAll();
            return Ok(UserModel.ToModel(users));
        }


        [HttpGet("{id}")]
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
                userLogic.Update(UserModel.ToEntity(model));
                return Ok();
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
                return Ok();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
