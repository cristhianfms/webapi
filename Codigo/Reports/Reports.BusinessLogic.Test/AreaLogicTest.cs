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
    public class AreaLogicTest
    {
        [TestMethod]
        public void CreateAreaOk()
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
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);

            AreaLogic areaLogic = new AreaLogic(areaRepo,areaManagerRepo,userRepo,indicatorRepo);
            areaLogic.CreateArea(area);
            var areas =  areaRepo.GetAll().ToList();
            Assert.AreEqual(areas[0].Name, "name");
        }
        [TestMethod]
        public void CreateAreaOkWithMock()
        {
            List<User> managers = new List<User>();
             User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };
            managers.Add(user);
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;
            var mockAreaRepo = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mockAreaRepo.Setup(m => m.Add(It.IsAny<Area>()));
            mockAreaRepo.Setup(m => m.Save());

            var mockAreaManagerRepo = new Mock<IRepository<AreaManager>>(MockBehavior.Strict);
            var mockUserRepo = new Mock<IRepository<User>>(MockBehavior.Strict);
            var mockIndicatorRepo = new Mock<IRepository<Indicator>>(MockBehavior.Strict);

            var areaLogic = new AreaLogic(mockAreaRepo.Object, mockAreaManagerRepo.Object, 
                mockUserRepo.Object,mockIndicatorRepo.Object);

            areaLogic.CreateArea(area);

            mockAreaRepo.VerifyAll();
        } 
        [TestMethod]  
        [ExpectedException(typeof(BusinessLogicException))]      
        public void CreateAreaNotOkNullName()
        {
            List<User> managers = new List<User>();
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = null;
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo, areaManagerRepo, userRepo, indicatorRepo);

            areaLogic.CreateArea(area);
            var areas =  areaRepo.GetAll().ToList();
        }


        [TestMethod]  
        [ExpectedException(typeof(BusinessLogicException))]           
        public void CreateAreaNotOkEmptyName()
        {
            List<User> managers = new List<User>();
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo, areaManagerRepo, userRepo, indicatorRepo);

            areaLogic.CreateArea(area);
            var areas =  areaRepo.GetAll().ToList();
        }
        [TestMethod]  
        [ExpectedException(typeof(BusinessLogicException))]         
        public void CreateAreaNotOkEmptyConnectionString()
        {
            List<User> managers = new List<User>();
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "";
            area.Indicators = indicators;
            
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo, areaManagerRepo, userRepo, indicatorRepo);

            areaLogic.CreateArea(area);
            var areas =  areaRepo.GetAll().ToList();
        }



        [TestMethod] 
        public void RemoveAreaOk()
        {
            List<User> managers = new List<User>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };
            managers.Add(user);
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo, areaManagerRepo, userRepo, indicatorRepo);

            areaLogic.CreateArea(area);
            areaLogic.RemoveArea(area);
            var areas =  areaRepo.GetAll().ToList();
            Assert.IsTrue(areas.Count == 0);
        }
        [TestMethod] 
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveAreaNotOk()
        {
            List<User> managers = new List<User>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };
            managers.Add(user);
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo, areaManagerRepo, userRepo, indicatorRepo);

            areaLogic.RemoveArea(area);
            var areas =  areaRepo.GetAll().ToList();
        }
        [TestMethod]
         public void RemoveAreaOkWithMock()
        {
            
            List<User> managers = new List<User>();
            List<Indicator> indicators = new List<Indicator>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };
            managers.Add(user);
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<Area>()));
            mock.Setup(m => m.Save());

            var mockAreaManagerRepo = new Mock<IRepository<AreaManager>>(MockBehavior.Strict);
            var mockUserRepo = new Mock<IRepository<User>>(MockBehavior.Strict);
            var mockIndicatorRepo = new Mock<IRepository<Indicator>>(MockBehavior.Strict);

            var areaLogic = new AreaLogic(mock.Object, mockAreaManagerRepo.Object,
                mockUserRepo.Object, mockIndicatorRepo.Object);


            areaLogic.RemoveArea(area);

            mock.VerifyAll();
        }
        [TestMethod]
         public void UpdateAreaOkWithMock()
        {
           
            List<User> managers = new List<User>();
            List<Indicator> indicators = new List<Indicator>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };
            managers.Add(user);
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<Area>()));
            mock.Setup(m => m.Save());

            var mockAreaManagerRepo = new Mock<IRepository<AreaManager>>(MockBehavior.Strict);
            var mockUserRepo = new Mock<IRepository<User>>(MockBehavior.Strict);
            var mockIndicatorRepo = new Mock<IRepository<Indicator>>(MockBehavior.Strict);

            var areaLogic = new AreaLogic(mock.Object, mockAreaManagerRepo.Object,
                mockUserRepo.Object, mockIndicatorRepo.Object);

            areaLogic.UpdateArea(area);

            mock.VerifyAll();
        }


        [TestMethod]
        public void UpdateAreaOkConnectionString()
        {
            List<User> managers = new List<User>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };
            managers.Add(user);
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo, areaManagerRepo, userRepo, indicatorRepo);

            areaLogic.CreateArea(area);
            area.ConnectionString = "connectionStringModified";
            areaLogic.UpdateArea(area);
            var areas =  areaRepo.GetAll().ToList();
            Assert.AreEqual(areas[0].ConnectionString, "connectionStringModified");
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void UpdateAreaEmptyConnectionString()
        {
            List<User> managers = new List<User>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };
            managers.Add(user);
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo, areaManagerRepo, userRepo, indicatorRepo);

            areaLogic.CreateArea(area);
            area.ConnectionString = "";
            areaLogic.UpdateArea(area);
            var areas =  areaRepo.GetAll().ToList();
        }
        [TestMethod] 
        [ExpectedException(typeof(BusinessLogicException))]
        public void UpdateAreaNotOk()
        {
            List<User> managers = new List<User>();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };
            managers.Add(user);
            List<Indicator> indicators = new List<Indicator>();
            Area area = new Area();
            Guid id = Guid.NewGuid();
            area.Id = id;
            area.Name = "name";
            area.ConnectionString = "connectionString";
            area.Indicators = indicators;

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Area> areaRepo = new AreaRepository(context);
            IRepository<AreaManager> areaManagerRepo = new AreaManagerRepository(context);
            IRepository<User> userRepo = new UserRepository(context);
            IRepository<Indicator> indicatorRepo = new IndicatorRepository(context);
            AreaLogic areaLogic = new AreaLogic(areaRepo, areaManagerRepo, userRepo, indicatorRepo);

            areaLogic.UpdateArea(area);
            var areas =  areaRepo.GetAll().ToList();
        }
    }
}
