using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports.Webapi.Models;
using Reports.Webapi.Controllers;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports.Webapi.Test
{
    [TestClass]
    public class AreasControllerTest
    {

        [TestMethod]
        public void CreateAreaOk()
        {
            IEnumerable<Indicator> indicators = new List<Indicator>();
            AreaModel area = new AreaModel()
            {
                Name = "Area1",
                ConnectionString = "ConnectionString",
                Id = Guid.NewGuid(),
                Indicators = IndicatorModel.ToModel(indicators).ToList(),
            };

            var mock = new Mock<IAreaLogic>(MockBehavior.Strict);
            mock.Setup(m => m.CreateArea(It.IsAny<Area>())).Returns(area.ToEntity);

            var controller = new AreasController(mock.Object);
            var result = controller.Post(area);
            var createdResult = result as CreatedAtRouteResult;

            mock.VerifyAll();
        }




        [TestMethod]
        public void CreateNotVaidArea()
        {
            var mock = new Mock<IAreaLogic>(MockBehavior.Strict);
            mock.Setup(m => m.CreateArea(null)).Throws(new BusinessLogicInterfaceException());

            var controller = new AreasController(mock.Object);
            var result = controller.Post(null);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }


        [TestMethod]
        public void GetAllAreas()
        {
            List<User> managers = new List<User>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
                Admin = false
            };
            managers.Add(user);
            IEnumerable<Indicator> indicators = new List<Indicator>();
            AreaModel area = new AreaModel()
            {
                Name = "Area1",
                ConnectionString = "ConnectionString",
                Id = Guid.NewGuid(),
                Indicators = IndicatorModel.ToModel(indicators).ToList(),
            };


            List<Area> areas = new List<Area>();
            areas.Add(AreaModel.ToEntity(area));

            var mock = new Mock<IAreaLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(areas);

            var controller = new AreasController(mock.Object);
            var result = controller.Get();

            var createdResult = result as OkObjectResult;
            var models = createdResult.Value as IEnumerable<AreaModel>;

            mock.VerifyAll();

            Assert.AreEqual(areas[0].Name, models.ToList<AreaModel>()[0].Name);
        }

        [TestMethod]
        public void GetAreaOK()
        {
            List<User> managers = new List<User>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
                Admin = false
            };
            managers.Add(user);
            IEnumerable<Indicator> indicators = new List<Indicator>();
            AreaModel area = new AreaModel()
            {
                Name = "Area1",
                ConnectionString = "ConnectionString",
                Id = Guid.NewGuid(),
                Indicators = IndicatorModel.ToModel(indicators).ToList(),
            };


            var mock = new Mock<IAreaLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Get(area.Id)).Returns(area.ToEntity());

            var controller = new AreasController(mock.Object);
            var result = controller.Get(area.Id);

            var createdResult = result as OkObjectResult;
            var model = createdResult.Value as AreaModel;

            mock.VerifyAll();

            Assert.AreEqual(area.Name, model.Name);

        }


        [TestMethod]
        public void GetNotExistingArea()
        {

            var mock = new Mock<IAreaLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Get(It.IsAny<Guid>())).Throws(new BusinessLogicInterfaceException());

            var controller = new AreasController(mock.Object);
            var result = controller.Get(Guid.NewGuid());
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));

        }

        [TestMethod]
        public void UpdateArea()
        {

            IEnumerable<Indicator> indicators = new List<Indicator>();
            AreaModel area = new AreaModel()
            {
                Name = "Area1",
                ConnectionString = "ConnectionString",
                Id = Guid.NewGuid(),
                Indicators = IndicatorModel.ToModel(indicators).ToList(),
            };


            var mock = new Mock<IAreaLogic>(MockBehavior.Strict);
            mock.Setup(m => m.UpdateArea(It.IsAny<Area>())).Returns(area.ToEntity());

            var controller = new AreasController(mock.Object);
            var result = controller.Put(area.Id, area);
            var createdResult = result as OkObjectResult;

            mock.VerifyAll();
        }

        [TestMethod]
        public void DeleteArea()
        {

            List<User> managers = new List<User>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
                Admin = false
            };
            managers.Add(user);
            IEnumerable<Indicator> indicators = new List<Indicator>();
            AreaModel area = new AreaModel()
            {
                Name = "Area1",
                ConnectionString = "ConnectionString",
                Id = Guid.NewGuid(),
                Indicators = IndicatorModel.ToModel(indicators).ToList(),
            };


            var mock = new Mock<IAreaLogic>(MockBehavior.Strict);
            mock.Setup(m => m.RemoveArea(It.IsAny<Area>()));

            var controller = new AreasController(mock.Object);
            var result = controller.Delete(area.Id, area);
            var createdResult = result as OkObjectResult;

            mock.VerifyAll();
        }



    }
}
