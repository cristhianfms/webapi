using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports.Domain;
using Reports.DataAccess;
using Reports.DataAccess.Interface;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Reports.BusinessLogic.Test
{
    [TestClass]
    public class UserLogicTest
    {
        [TestMethod]
        public void CreateUserOK()
        {
            
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Create(user);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CreateNullUser()
        {
            User user = null;

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);
            userLogic.Create(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CreateEmptyName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);
            userLogic.Create(user);
        }



        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CreateEmptyLastName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);
            userLogic.Create(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CreateEmptyUserName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);
            userLogic.Create(user);
        }


        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CreateEmptyPassword()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
                    mock.Setup(m => m.Save());
                    var userLogic = new UserLogic(mock.Object);
            userLogic.Create(user);
        }



        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CreateEmptyID()
        {
            User user = new User
            {
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "SantiL",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);
            userLogic.Create(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CreateExistingGuid()
        {
            Guid id = Guid.NewGuid();

            User user1 = new User
            {
                Id = id,
                Name = "Santiago1",
                LastName = "Larralde1",
                UserName = "Santi1",
                Password = "123456",
            };

            User user2 = new User
            {
                Id = id,
                Name = "Santiago2",
                LastName = "Larralde2",
                UserName = "Santi2",
                Password = "123456",
            };

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<User> userRepo = new UserRepository(context);
            UserLogic userLogic = new UserLogic(userRepo);
            userLogic.Create(user1);
            userLogic.Create(user2);
        }




        
        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void CreateExistingUserName()
        {
            String sameUserName = "user1";

            User user1 = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago1",
                LastName = "Larralde1",
                UserName = sameUserName,
                Password = "123456",
            };

            User user2 = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago2",
                LastName = "Larralde2",
                UserName = sameUserName,
                Password = "123456",
            };

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<User> userRepo = new UserRepository(context);
            UserLogic userLogic = new UserLogic(userRepo);
            userLogic.Create(user1);
            userLogic.Create(user2);
        }


        [TestMethod]
        public void GetUserOK()
        {
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<User> userRepo = new UserRepository(context);
            UserLogic userLogic = new UserLogic(userRepo);

            Guid id = Guid.NewGuid();
            User user = new User
            {
                Id = id,
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            userLogic.Create(user);
            User fetchedUser = userLogic.Get(id);

            Assert.AreEqual(fetchedUser.Name, user.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void GetNotExistingUser()
        {
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<User> userRepo = new UserRepository(context);
            UserLogic userLogic = new UserLogic(userRepo);

            Guid id = Guid.NewGuid();
            User user = new User
            {
                Id = id,
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            userLogic.Create(user);
            User fetchedUser = userLogic.Get(Guid.NewGuid());
        }

        [TestMethod]
        public void GetAllOK()
        {
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<User> userRepo = new UserRepository(context);
            UserLogic userLogic = new UserLogic(userRepo);

            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            userLogic.Create(user);
            List<User> users = userLogic.GetAll().ToList();
            Assert.AreEqual(users[0].Name, user.Name);
        }

        [TestMethod]
        public void RemoveUserOK()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Remove(user);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveNotExistingUser()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<User> userRepo = new UserRepository(context);
            UserLogic userLogic = new UserLogic(userRepo);
            userLogic.Remove(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveEmptyName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Remove(user);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveEmptyPassword()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Remove(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveEmptyLastName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Remove(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveEmptyUserName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Remove(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveEmptyID()
        {
            User user = new User
            {
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Remove(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void RemoveEmptyRol()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Remove(user);
        }

        [TestMethod]
        public void UpdateUserOK()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Update(user);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void UpdateNotExistingUser()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<User> userRepo = new UserRepository(context);
            UserLogic userLogic = new UserLogic(userRepo);
            userLogic.Update(user);
        }


        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void UpdatEmptyName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Update(user);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void UpdateEmptyPassword()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Update(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void UpdateEmptyLastName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "",
                UserName = "Santi",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Update(user);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void UpdateEmptyUserName()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Update(user);

        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException))]
        public void UpdateEmptyGUID()
        {
            User user = new User
            {
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi1",
                Password = "123456",
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Update(user);
        }


    }
}
