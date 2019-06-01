using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.BusinessLogic.Interface;
using Reports.Webapi.Filters;
using Reports.Logger.Interface;

namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private ISessionLogic sessions;
        private ILoggerLogic logger;

        public TokenController(ISessionLogic sessions, ILoggerLogic logger) : base()
        {
            this.sessions = sessions;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginModel model) {
            var token = sessions.CreateToken(model.UserName, model.Password);
            if (token == null) 
            {
                return BadRequest("Invalid user/password");
            }
            var addlog = logger.Create(LogModel.ToEntity(new LogModel {
                Id = new Guid(),
                UserName = model.UserName,
                Date = DateTime.Now,
                Action = "Login"
            }));
            return Ok(token);
        }

        [ProtectFilter("Admin")]
        [HttpGet("Check")]
        public IActionResult CheckLogin() {
            return Ok(new UserModel(sessions.GetUser(Request.Headers["Authorization"])));
        }

    }
}
