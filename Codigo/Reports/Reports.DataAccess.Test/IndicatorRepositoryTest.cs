using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports.DataAccess;
using Reports.DataAccess.Interface;
using Reports.Domain;
using System.Linq;
using System.Collections.Generic;

namespace Reports.DataAccess.Test
{
    [TestClass]
    public class IndicatorRepositoryTest
    {
        [TestMethod]
        public void AddIndicatorOK()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Add(indicator);
            indicatorRepo.Save();
            var indicators =  indicatorRepo.GetAll().ToList();
            Assert.AreEqual(indicators[0].Color, "red");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void AddIndicatorWithSameId()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            Indicator indicator2 = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Add(indicator);
            indicatorRepo.Save();
            indicator2.Id = id;
            indicator2.Color = color;
            indicator2.Condition = component;
            indicatorRepo.Add(indicator2);
            indicatorRepo.Save();
        }   
        [TestMethod]
        public void RemoveIndicatorOK()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Add(indicator);
            indicatorRepo.Save();
            indicatorRepo.Remove(indicator);
            indicatorRepo.Save();
            var indicators =  indicatorRepo.GetAll().ToList();
             Assert.AreEqual(indicators.Count, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void RemoveIndicatorNotExist()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Remove(indicator);
            indicatorRepo.Save();
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void RemoveIndicatorNotExist2()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            Indicator indicator2 = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Add(indicator);
            indicatorRepo.Save();
            indicator2.Id = id2;
            indicator2.Color = color;
            indicator2.Condition = component;
            indicatorRepo.Remove(indicator2);
            indicatorRepo.Save();
        }
        [TestMethod]
        public void UpdateIndicatorOK()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Add(indicator);
            indicatorRepo.Save();
            string colorUpdate = "yellow";
            indicator.Color = colorUpdate;
            indicatorRepo.Update(indicator);
            var indicators =  indicatorRepo.GetAll().ToList();
            Assert.AreEqual(indicators[0].Color, "yellow");
        }
        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UpdateIndicatorNotExist()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Update(indicator);
            indicatorRepo.Save();
        }
        [TestMethod]
        public void GetIndicatorByIdOK()
        { 
             string contextName = Guid.NewGuid().ToString();
            var context = ContextFactory.GetMemoryContext(contextName);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Add(indicator);
            indicatorRepo.Save();

            context = ContextFactory.GetMemoryContext(contextName);
            indicatorRepo = new IndicatorRepository(context); 
            Indicator obtainedIndicator = indicatorRepo.Get(id);

            Assert.AreEqual(obtainedIndicator.Id, indicator.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void getAllIndicatorsNotOk()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
           Indicator indicators = indicatorRepo.Get(id);
        } 
        [TestMethod]
        public void getAllIndicatorsOK()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            Indicator indicator2 = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Add(indicator);
            indicatorRepo.Save();
            indicator2.Id = id2;
            indicator2.Color = color;
            indicator2.Condition = component;
            indicatorRepo.Add(indicator2);
            indicatorRepo.Save();
            List<Indicator>  indicators = indicatorRepo.GetAll().ToList();
            Assert.AreEqual(indicators.Count(), 2);
        } 
        [TestMethod]
        public void getAllIndicatorsOK2()
        { 
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            string color = "red";
            BaseCondition component = new Condition();
            Indicator indicator = new Indicator();
            Indicator indicator2 = new Indicator();
            indicator.Id = id;
            indicator.Color = color;
            indicator.Condition = component;
            indicatorRepo.Add(indicator);
            indicatorRepo.Save();
            indicator2.Id = id2;
            indicator2.Color = color;
            indicator2.Condition = component;
            indicatorRepo.Add(indicator2);
            indicatorRepo.Save();
            List<Indicator>  indicators = indicatorRepo.GetAll().ToList();
            Assert.IsTrue(indicators[0].Id == id && indicators[1].Id == id2);
        } 
        
    }
}