﻿using System;
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
        private IIndicatorDisplayLogic indicatorDisplayLogic;

        public UsersController(IUserLogic userLogic) : base()
        {
            this.userLogic = userLogic;
        }
        public UsersController(IIndicatorDisplayLogic indicatorDisplayLogic) : base()
        {
            this.indicatorDisplayLogic = indicatorDisplayLogic;
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
         public IActionResult GetAllIndicatorByUserId(Guid id){
              try
            {
                indicatorDisplayLogic.GetAllByManagerId(id);
                return Ok();
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
                return Ok();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
