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
    public class AreaRepositoryTest
    {
        [TestMethod]
        public void AddAreaOK()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);

            string name = "Administration";
            string connectionString = "a connection string";
            List<User> managers = new List<User>();
            User aManager = new User();
            managers.Add(aManager);
            List<Indicator> indicators = new List<Indicator>();
            Indicator indicator = new Indicator();
            indicators.Add(indicator);
            areaRepo.Add(new Area{
                Id = Guid.NewGuid(),
                Name = name,
                ConnectionString = connectionString,
                Managers = managers,
                Indicators = indicators
            }); 
            areaRepo.Save();

            var areas =  areaRepo.GetAll().ToList();
            Assert.AreEqual(areas[0].Name, "Administration");
        }
         
        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void AddAreaWithSameId()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);

            string name = "Administration";
            string connectionString = "a connection string";
            List<User> managers = new List<User>();
            User aManager = new User();
            managers.Add(aManager);
            List<Indicator> indicators = new List<Indicator>();
            Indicator indicator = new Indicator();
            indicators.Add(indicator);
            areaRepo.Add(new Area{
                Id = new Guid("00000000000000000000000000000001"),
                Name = name,
                ConnectionString = connectionString,
                Managers = managers,
                Indicators = indicators
            }); 
            areaRepo.Add(new Area{
                Id = new Guid("00000000000000000000000000000001"),
                Name = name,
                ConnectionString = connectionString,
                Managers = managers,
                Indicators = indicators
            }); 
            areaRepo.Save();
        }
    [TestMethod]
        public void RemoveAreaOK()
        {   
            Guid guid = Guid.NewGuid();
            var context = ContextFactory.GetMemoryContext(guid.ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);

            string name = "Administration";
            string connectionString = "a connection string";
            List<User> managers = new List<User>();
            User aManager = new User();
            managers.Add(aManager);
            List<Indicator> indicators = new List<Indicator>();
            Indicator indicator = new Indicator();
            indicators.Add(indicator);
            Area area = new Area();
            area.Id = Guid.NewGuid();
            area.Name = name;
            area.ConnectionString = connectionString;
            area.Managers = managers;
            area.Indicators = indicators;
            areaRepo.Add(area); 
            areaRepo.Save();

            context = ContextFactory.GetMemoryContext(guid.ToString());
            areaRepo = new AreaRepository(context);
            areaRepo.Remove(area);
            areaRepo.Save();
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
                public void RemoveAreaNotInMemoryOK()
        {   
            var context = ContextFactory.GetMemoryContext("sameId");
            IRepository<Area> areaRepo = new AreaRepository(context);

            string name = "Administration";
            string connectionString = "a connection string";
            List<User> managers = new List<User>();
            User aManager = new User();
            managers.Add(aManager);
            List<Indicator> indicators = new List<Indicator>();
            Indicator indicator = new Indicator();
            indicators.Add(indicator);
            Area area = new Area();
            area.Id = Guid.NewGuid();
            area.Name = name;
            area.ConnectionString = connectionString;
            area.Managers = managers;
            area.Indicators = indicators;
            areaRepo.Add(area); 
            areaRepo.Save();

            context = ContextFactory.GetMemoryContext("sameId");
            areaRepo = new AreaRepository(context);
            Area area1 = new Area();
            area1.Id = Guid.NewGuid();
            area1.Name = name;
            area1.ConnectionString = connectionString;
            area1.Managers = managers;
            area1.Indicators = indicators;
            areaRepo.Remove(area1);
            areaRepo.Save();
        }

           [TestMethod]
        public void UpdateAreaOK()
        {   
            var context = ContextFactory.GetMemoryContext("sameId2");
            IRepository<Area> areaRepo = new AreaRepository(context);

            string name = "Administration";
            string connectionString = "a connection string";
            List<User> managers = new List<User>();
            User aManager = new User();
            managers.Add(aManager);
            List<Indicator> indicators = new List<Indicator>();
            Indicator indicator = new Indicator();
            indicators.Add(indicator);
            Area area = new Area();
            area.Id = Guid.NewGuid();
            area.Name = name;
            area.ConnectionString = connectionString;
            area.Managers = managers;
            area.Indicators = indicators;
            areaRepo.Add(area); 
            areaRepo.Save();
            
            area.Name = "RR.HH";
            context = ContextFactory.GetMemoryContext("sameId2");
            areaRepo = new AreaRepository(context);
            areaRepo.Update(area);
            areaRepo.Save();

            var areas =  areaRepo.GetAll().ToList();
            Assert.AreEqual(areas[0].Name, "RR.HH");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UpdateAreaWithOutId()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);

            string name = "Administration";
            string connectionString = "a connection string";
            List<User> managers = new List<User>();
            User aManager = new User();
            managers.Add(aManager);
            List<Indicator> indicators = new List<Indicator>();
            Indicator indicator = new Indicator();
            indicators.Add(indicator);
            Area area = new Area();
            area.Id = Guid.NewGuid();
            area.Name = name;
            area.ConnectionString = connectionString;
            area.Managers = managers;
            area.Indicators = indicators;
            areaRepo.Add(area); 
            areaRepo.Update(area);
            areaRepo.Save();
        }

        [TestMethod]
        public void GetAllAreaOK()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);

            string name = "Administration";
            string connectionString = "a connection string";
            List<User> managers = new List<User>();
            User aManager = new User();
            managers.Add(aManager);
            List<Indicator> indicators = new List<Indicator>();
            Indicator indicator = new Indicator();
            indicators.Add(indicator);
            Guid id = Guid.NewGuid();
            Guid id1 = Guid.NewGuid();
            Area area = new Area();
            area.Id = id;
            area.Name = name;
            area.ConnectionString = connectionString;
            area.Managers = managers;
            area.Indicators = indicators;
            areaRepo.Add(area); 
            Area area1 = new Area();
            area1.Id = id1;
            area1.Name = "name";
            area1.ConnectionString = connectionString;
            area1.Managers = managers;
            area1.Indicators = indicators;
            areaRepo.Add(area1); 
            areaRepo.Save();
        

            var areas =  areaRepo.GetAll().ToList();
            Assert.IsTrue(areas[0].Id == id && areas[1].Id == id1);
            
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void GetWhitOutId()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            var areas =  areaRepo.Get(Guid.NewGuid());
        }

        [TestMethod]
         public void GetAreaOK()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);

            string name = "Administration";
            string connectionString = "a connection string";
            List<User> managers = new List<User>();
            User aManager = new User();
            managers.Add(aManager);
            List<Indicator> indicators = new List<Indicator>();
            Indicator indicator = new Indicator();
            indicators.Add(indicator);
            Guid id = Guid.NewGuid();
            Area area = new Area();
            area.Id = id;
            area.Name = name;
            area.ConnectionString = connectionString;
            area.Managers = managers;
            area.Indicators = indicators;
            areaRepo.Add(area);  
            areaRepo.Save();
        

            var area1 =  areaRepo.Get(id);
            Assert.IsTrue(area1.Id == id);
            
        }


    }
}