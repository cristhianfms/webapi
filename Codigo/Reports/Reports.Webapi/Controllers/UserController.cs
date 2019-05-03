﻿using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Domain;
using Reports.BusinessLogic.Interface;


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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }





    }
}
