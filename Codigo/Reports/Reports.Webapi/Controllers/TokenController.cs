using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
using Reports.Filter;

namespace Reports.Webapi.Controllers{


    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private ISessionLogic sessionLogic;

        public TokenController(ISessionLogic sessionLogic) : base()
        {
            this.sessionLogic = sessionLogic;
        }

        [HttpPost]
        public IActionResult Login([FromBody]SessionModel model) {
            var token = sessionLogic.CreateToken(model.User.Id, model.User.Password);
            if (token == null) 
            {
                return BadRequest("Invalid user/password");
            }
            return Ok(token);
        }

        [ProtectFilter(true)]
        [HttpGet("Check")]
        public IActionResult CheckLogin() {
            return Ok(new UserModel(sessionLogic.GetUser(Request.Headers["Authorization"])));
        }

    }
}