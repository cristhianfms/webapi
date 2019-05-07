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
    public class IndicatorsControllerTests
    {
        [TestMethod]
        public void CreateIndicatorOk()
        {
            Component component = new Condition()
            {

                Id = Guid.NewGuid(),
                ValueIzq = new StringValue { Value = "hola" },
                ValueDer = new StringValue { Value = "hola" },
                Operation = "="
            };
            Indicator  indicator = new Indicator()
            {
                Color = "red",
                Id = Guid.NewGuid(),
                Component = component
            };


            var mock = new Mock<IIndicatorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Create(It.IsAny<Indicator>()));

            var controller = new IndicatorsController(mock.Object);
            var result = controller.Post(IndicatorModel.ToModel(indicator));
            var createdResult = result as CreatedAtRouteResult;

            mock.VerifyAll();
        }





        [TestMethod]
        public void CreateNotVaidIndicator()
        {
            var mock = new Mock<IIndicatorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Create(null)).Throws(new BusinessLogicInterfaceException());

            var controller = new IndicatorsController(mock.Object);
            var result = controller.Post(null);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }


        [TestMethod]
        public void GetAllIndicators()
        {
            Component component = new Condition()
            {
                Id = Guid.NewGuid(),
                ValueIzq = new StringValue { Value = "hola" },
                ValueDer = new StringValue { Value = "hola" },
                Operation = "="
            };
            Indicator indicator = new Indicator()
            {
                Color = "red",
                Id = Guid.NewGuid(),
                Component = component
            };


            List<Indicator> indicators = new List<Indicator>();
            indicators.Add(indicator);

            var mock = new Mock<IIndicatorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(indicators);

            var controller = new IndicatorsController(mock.Object);
            var result = controller.Get();
            var createdResult = result as OkObjectResult;
            var models = createdResult.Value as IEnumerable<IndicatorModel>;

            mock.VerifyAll();

            Assert.AreEqual(indicators[0].Color, models.ToList<IndicatorModel>()[0].Color);
        }

        [TestMethod]
        public void GetIndicatorOK()
        {
            Component component = new Condition()
            {
                Id = Guid.NewGuid(),
                ValueIzq = new StringValue { Value = "hola" },
                ValueDer = new StringValue { Value = "hola" },
                Operation = "="
            };
            Indicator indicator = new Indicator()
            {
                Color = "red",
                Id = Guid.NewGuid(),
                Component = component
            };

            var mock = new Mock<IIndicatorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Get(indicator.Id)).Returns(indicator);

            var controller = new IndicatorsController(mock.Object);
            var result = controller.Get(indicator.Id);
            var createdResult = result as OkObjectResult;
            var model = createdResult.Value as IndicatorModel;

            Assert.AreEqual(indicator.Color,model.Color);
        }


        [TestMethod]
        public void GetNotExistingIndicator()
        {
            var mock = new Mock<IIndicatorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Get(It.IsAny<Guid>())).Throws(new BusinessLogicInterfaceException());

            var controller = new IndicatorsController(mock.Object);
            var result = controller.Get(Guid.NewGuid());

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }


        [TestMethod]
        public void UpdateIndicator()
        {
            Component component = new Condition()
            {
                Id = Guid.NewGuid(),
                ValueIzq = new StringValue { Value = "hola" },
                ValueDer = new StringValue { Value = "hola" },
                Operation = "="
            };
            Indicator indicator = new Indicator()
            {
                Color = "red",
                Id = Guid.NewGuid(),
                Component = component
            };


            var mock = new Mock<IIndicatorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<Indicator>()));

            var controller = new IndicatorsController(mock.Object);
            var result = controller.Put(indicator.Id, IndicatorModel.ToModel(indicator));

            mock.VerifyAll();
        }



        [TestMethod]
        public void DeleteIndicator()
        {

            Component component = new Condition()
            {
                Id = Guid.NewGuid(),
                ValueIzq = new StringValue { Value = "hola" },
                ValueDer = new StringValue { Value = "hola" },
                Operation = "="
            };
            Indicator indicator = new Indicator()
            {
                Color = "red",
                Id = Guid.NewGuid(),
                Component = component
            };


            var mock = new Mock<IIndicatorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<Indicator>()));

            var controller = new IndicatorsController(mock.Object);
            var result = controller.Delete(indicator.Id, IndicatorModel.ToModel(indicator));

            mock.VerifyAll();
        }


    }
}
