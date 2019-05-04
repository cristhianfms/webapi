using System;
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


        [HttpPost]
        public IActionResult Post([FromBody]UserModel model)
        {
            try
            {
                User user = UserModel.ToEntity(model);
                user.Id = new Guid();
                userLogic.Create(UserModel.ToEntity(model));
                return Ok();
            }
            catch (BusinessLogicInterfaceException e)
            {
                return BadRequest(e.Message);
            }
        }





    }
}
