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
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == true);
        }

        [TestMethod]
        public void CreateIndicatorStringValeExpresionEqualOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "chau"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == false);
        }
       [TestMethod]
        public void CreateIndicatorLogicExpresionAndOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component componentIzq = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            ValueExpression izq1 = new StringValue{Avalue = "hola"};
            ValueExpression der1 = new StringValue{Avalue = "hola"};
            Component componentDer = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Component component = new LogicAnd
            {
                CompIzq = componentIzq,
                CompDer = componentDer,
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorIntValeExpresioLessnOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new IntValue{Avalue = 1};
            ValueExpression der = new IntValue{Avalue = 1};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.less
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == false);
        }
        [TestMethod]
        public void CreateIndicatorIntValeExpresionLessOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new IntValue{Avalue = 1};
            ValueExpression der = new IntValue{Avalue = 2};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.less
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorIntValeExpresionGraterOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new StringValue{Avalue = "3"};
            ValueExpression der = new IntValue{Avalue = 2};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.greater
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorIntValeExpresionGraterOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new IntValue{Avalue = 3};
            ValueExpression der = new StringValue{Avalue = "4"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.greater
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == false);
        }
        [TestMethod]
        public void CreateIndicatorStringValeExpresionLessEqualOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new StringValue{Avalue = "hol"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.lessEqual
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorStringValeExpresionLessEqualOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new StringValue{Avalue = "holaa"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.lessEqual
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == false);
        }
                [TestMethod]
        public void CreateIndicatorStringValeExpresionGraterEqualOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new IntValue{Avalue = 1};
            ValueExpression der = new IntValue{Avalue = 3};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.greatEqual
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == false);
        }
        [TestMethod]
        public void CreateIndicatorStringValeExpresionGraterEqualOk2()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new IntValue{Avalue = 3};
            ValueExpression der = new IntValue{Avalue = 2};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.greatEqual
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void CreateIndicatorLogicExpresionOrOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component componentIzq = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            ValueExpression izq1 = new StringValue{Avalue = "hola"};
            ValueExpression der1 = new StringValue{Avalue = "chau"};
            Component componentDer = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Component component = new LogicOr
            {
                CompIzq = componentIzq,
                CompDer = componentDer,
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);
            var components =  indicatorRepo.GetAll().ToList();
            bool res = components[0].Component.Evaluete();
            Assert.IsTrue(res == true);
        }
        [TestMethod]
        public void RemoveIndicatorStringValeExpresionEqualOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
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
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
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
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
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
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "chau"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
            };
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            IndicatorLogic indicatroLogic = new IndicatorLogic(indicatorRepo);
            indicatroLogic.Create(indicator);

            ValueExpression izq1 = new StringValue{Avalue = "hola"};
            ValueExpression der1 = new StringValue{Avalue = "hola"};
            Component component2 = new Condition
            {
                ValueIzq = izq1,
                ValueDer = der1,
                Operation = Comparator.equal
            };
            indicator.Component = component2;
            indicatroLogic.Update(indicator);
            var indicators =  indicatorRepo.GetAll().ToList();
            bool res = indicators[0].Component.Evaluete();
            Assert.IsTrue(res == true);
        }
        [TestMethod] 
        [ExpectedException(typeof(BusinessLogicException))]
        public void UdateIndicatorStringValeExpresionEqualNotOk()
        {
            Guid id = Guid.NewGuid();
            string color = "red";
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
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
            ValueExpression izq = new StringValue{Avalue = "hola"};
            ValueExpression der = new StringValue{Avalue = "hola"};
            Component component = new Condition
            {
                ValueIzq = izq,
                ValueDer = der,
                Operation = Comparator.equal
            };
            Indicator indicator = new Indicator{
                Color = color,
                Id = id,
                Component = component
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