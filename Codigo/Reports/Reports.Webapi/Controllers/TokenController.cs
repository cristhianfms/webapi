using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
using Reports.Webapi.Filters;
using System.Linq;
using Reports.Logger.Interface;
using Reports.Domain;

namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private ILoggerLogic logger;
        private ISessionLogic sessions;
        private IUserLogic userLogic;

        public TokenController(ISessionLogic sessions, IUserLogic userLogic, ILoggerLogic logger) : base()
        {
            this.sessions = sessions;
            this.userLogic = userLogic;
            this.logger = logger;
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
            var addlog = logger.Create(LogModel.ToEntity(new LogModel {
                Id = new Guid(),
                UserName = model.UserName,
                Date = DateTime.Now,
                Action = ActionType.LOGIN,
                Role = user.Admin ? UserRoleType.ADMIN : UserRoleType.MANAGER
            }));
            return Ok(modelToReturn);
        }

        [ProtectFilter("Admin")]
        [HttpGet("Check")]
        public IActionResult CheckLogin() {
            return Ok(new UserModel(sessions.GetUser(Request.Headers["Authorization"])));
        }

    }
}
