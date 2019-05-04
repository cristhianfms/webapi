using System;
using Microsoft.AspNetCore.Mvc;
using Reports.Webapi.Models;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;

namespace Reports.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {

        private IAreaLogic areaLogic;

        public AreasController(IAreaLogic areaLogic) : base()
        {
            this.areaLogic = areaLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Area> areas = areaLogic.GetAll();
            return Ok(AreaModel.ToModel(areas));
        }













    }
}
