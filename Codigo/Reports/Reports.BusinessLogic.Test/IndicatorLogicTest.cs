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
        public void CreateIndicatorOk()
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
    }
}