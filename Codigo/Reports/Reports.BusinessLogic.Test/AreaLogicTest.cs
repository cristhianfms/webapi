using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports.DataAccess;
using Reports.DataAccess.Interface;
using Reports.Domain;
using Reports.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Reports.BusinessLogic.Test
{
    [TestClass]
    public class AreaLogicTest
    {
        [TestMethod]
        public void CreateAreaOk()
        {
            List<User> managers = new List<User>();
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Managers = managers;
            area.Indicators = indicators;
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo);
            areaLogic.CreateArea(area);
            var areas =  areaRepo.GetAll().ToList();
            Assert.AreEqual(areas[0].Name, "name");
        }
    }
}
