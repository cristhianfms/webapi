using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
using Homeworks.Webapi.Filters;
using System.Linq;


namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private ISessionLogic sessions;
        private IUserLogic userLogic;

        public TokenController(ISessionLogic sessions, IUserLogic userLogic) : base()
        {
            this.sessions = sessions;
            this.userLogic = userLogic;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginModel model) {
            var token = sessions.CreateToken(model.UserName, model.Password);
            User user = userLogic.GetAll().FirstOrDefault(u => u.UserName == model.UserName);
            var modelToReturn = TokenUserModel.ToModel(user);
            modelToReturn.Token = token;

            if (token == null) 
            {
                return BadRequest("Invalid user/password");
            }
            return Ok(token);
        }

        [ProtectFilter("Admin")]
        [HttpGet("Check")]
        public IActionResult CheckLogin() {
            return Ok(new UserModel(sessions.GetUser(Request.Headers["Authorization"]).User));
        }

    }
}
