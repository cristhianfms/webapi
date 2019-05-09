using System;
using Microsoft.AspNetCore.Mvc;
using Reports.BusinessLogic.Interface;
using Homeworks.Webapi.Filters;
using Reports.Webapi.Models;

namespace Homeworks.WebApi.Controllers
{
    [ProtectFilter("User")]
    [Route("api/[controller]")]
    public class ProtectedController : ControllerBase
    { 
        private ISessionLogic sessions;

        public ProtectedController(ISessionLogic sessions) : base()
        {
            this.sessions = sessions;
        }

        [ProtectFilter("Admin")]
        [HttpGet("CheckAdmin")]
        public IActionResult CheckLoginAdmin() {
            return Ok(new UserModel(sessions.GetUser(Request.Headers["Authorization"]).User));
        }

        [ProtectFilter("User")]
        [HttpGet("CheckUser")]
        public IActionResult CheckLoginUser() {
            return Ok(new UserModel(sessions.GetUser(Request.Headers["Authorization"]).User));
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok("The token is valid");
        }
    }
}