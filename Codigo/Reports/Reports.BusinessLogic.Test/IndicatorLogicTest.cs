using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports.DataAccess;
using Reports.DataAccess.Interface;
using Reports.Domain;
using Reports.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System;
using Moq;

namespace Reports.BusinessLogic.Test
{
    [TestClass]
    public class IndicatorLogicTest
    {
        [TestMethod]
        public void CreateIndicatorStringValeExpresionEqualOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "hola"};
            Value der = new StringValue{Data = "hola"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == true);
        }

        [TestMethod]
        public void CreateIndicatorStringValeExpresionEqualOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue { Data = "hola" };
            Value der = new StringValue { Data = "chau" };
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Indicator indicator = new Indicator
            {
                Color = color,
                Id = id,
                Condition = component
            };

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == false);
        }
       [TestMethod]
        public void CreateIndicatorLogicExpresionAndOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";

            Value izq = new StringValue{ Data = "hola"};
            Value der = new StringValue{ Data = "hola"};
            BaseCondition componentIzq = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Value izq1 = new StringValue{Data = "hola"};
            Value der1 = new StringValue{Data = "hola"};

            BaseCondition componentDer = new Condition()
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };

            BaseCondition component = new AndCondition()
            {
                Izq = componentIzq,
                Der = componentDer,
            };

            Indicator indicator = new Indicator(){
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorIntValeExpresioLessnOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new IntValue{Data = 1};
            Value der = new IntValue{Data = 1};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "<"
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == false);
        }
        [TestMethod]
        public void CreateIndicatorIntValeExpresionLessOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new IntValue{Data = 1};
            Value der = new IntValue{Data = 2};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "<"
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorIntValeExpresionGraterOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "3"};
            Value der = new IntValue{Data = 2};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = ">"
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorIntValeExpresionGraterOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new IntValue{Data = 3};
            Value der = new StringValue{Data = "4"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = ">"
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == false);
        }
        [TestMethod]
        public void CreateIndicatorStringValeExpresionLessEqualOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "hol"};
            Value der = new StringValue{Data = "hola"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "<="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorStringValeExpresionLessEqualOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "holaa"};
            Value der = new StringValue{Data = "hola"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "<="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == false);
        }
                [TestMethod]
        public void CreateIndicatorStringValeExpresionGraterEqualOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new IntValue{Data = 1};
            Value der = new IntValue{Data = 3};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = ">="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == false);
        }
        [TestMethod]
        public void CreateIndicatorStringValeExpresionGraterEqualOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new IntValue{Data = 3};
            Value der = new IntValue{Data = 2};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = ">="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorLogicExpresionOrOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "hola"};
            Value der = new StringValue{Data = "hola"};
            BaseCondition componentIzq = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Value izq1 = new StringValue{Data = "hola"};
            Value der1 = new StringValue{Data = "chau"};
            BaseCondition componentDer = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            BaseCondition component = new OrCondition
            {
                Izq = componentIzq,
                Der = componentDer,
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Condition.Eval();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void RemoveIndicatorStringValeExpresionEqualOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "hola"};
            Value der = new StringValue{Data = "hola"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            indicatroLogic.Remove(indicator);
            var indicators =  indicatorRepo.GetAll().ToList();
            Assert.IsTrue(indicators.Count == 0);
        }
        [TestMethod] 
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveIndicatorStringValeExpresionEqualNotOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "hola"};
            Value der = new StringValue{Data = "hola"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Remove(indicator);
        }
        [TestMethod]
        public void RemoveIndicatorStringValeExpresionEqualmockOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "hola"};
            Value der = new StringValue{Data = "hola"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var mock = new Mock<IRepository<Indicator>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<Indicator>()));
            mock.Setup(m => m.Save());
            IndicatorLogic indicatorLogic = new IndicatorLogic(mock.Object);

            indicatorLogic.Remove(indicator);

            mock.VerifyAll();
        }
        [TestMethod]
        public void UpdateIndicatorStringValeExpresionEqualOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "hola"};
            Value der = new StringValue{Data = "chau"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);

            Value izq1 = new StringValue{ Data = "hola"};
            Value der1 = new StringValue{ Data = "hola"};
            BaseCondition component2 = new Condition
            {
                ValueIzq = izq1,
                ValueDer = der1,
                Operator = "="
            };
            indicator.Condition = component2;
            indicatroLogic.Update(indicator);
            var indicators =  indicatorRepo.GetAll().ToList();
            bool res = indicators[0].Condition.Eval();
            Assert.IsTrue(res == true);
        }
        [TestMethod] 
        [ExpectedException(typeof(BusinessLogicException))]
        public void UdateIndicatorStringValeExpresionEqualNotOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{ Data = "hola"};
            Value der = new StringValue{ Data = "hola"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Update(indicator);
        }
        [TestMethod]
        public void UpdateIndicatorStringValeExpresionEqualmockOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            Value izq = new StringValue{Data = "hola"};
            Value der = new StringValue{ Data = "hola"};
            BaseCondition component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operator = "="
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Condition = component
            };
            var mock = new Mock<IRepository<Indicator>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<Indicator>()));
            mock.Setup(m => m.Save());
            IndicatorLogic indicatorLogic = new IndicatorLogic(mock.Object);

            indicatorLogic.Update(indicator);

            mock.VerifyAll();
        }
    }
}