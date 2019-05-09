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
    public class UsersControllerTest
    {
        [TestMethod]
        public void CreateUserOk()
        {
            UserModel user = new UserModel
            {
                Name = "Santiago",
                LastName = "Larralde",
                UserName = "Santi",
                Password = "123456",
                Admin = true
            };

            var mock = new Mock<IUserLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Create(It.IsAny<User>())).Returns(user.ToEntity());

            var mockIDL = new Mock<IIndicatorDisplayLogic>(MockBehavior.Strict);
            var mockIL = new Mock<IIndicatorLogic>(MockBehavior.Strict);

            var controller = new UsersController(mock.Object,mockIDL.Object,mockIL.Object);

            var result = controller.Post(user);
            var createdResult = result as CreatedAtRouteResult;
            
            mock.VerifyAll();
        }


        [TestMethod]
        public void CreateNotVaidUser()
        {
            var mock = new Mock<IUserLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Create(null)).Throws(new BusinessLogicInterfaceException());

            var mockIDL = new Mock<IIndicatorDisplayLogic>(MockBehavior.Strict);
            var mockIL = new Mock<IIndicatorLogic>(MockBehavior.Strict);

            var controller = new UsersController(mock.Object, mockIDL.Object, mockIL.Object);

            var result = controller.Post(null);
            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }


        [TestMethod]
        public void GetAllUsers()
        {
            UserModel user1 = new UserModel
            {
                Name = "Cristhian",
                LastName = "Maciel",
                UserName = "Cris",
                Password = "123456",
                Admin = true
            };

            List<User> users = new List<User>();
            users.Add(UserModel.ToEntity(user1));
            
            var mock = new Mock<IUserLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(users);
            var mockIDL = new Mock<IIndicatorDisplayLogic>(MockBehavior.Strict);
            var mockIL = new Mock<IIndicatorLogic>(MockBehavior.Strict);

            var controller = new UsersController(mock.Object, mockIDL.Object, mockIL.Object);
            var result = controller.Get();

            var createdResult = result as OkObjectResult;
            var models = createdResult.Value as IEnumerable<UserModel>;

            mock.VerifyAll();

            Assert.AreEqual(users[0].UserName, models.ToList<UserModel>()[0].UserName);
        }

        [TestMethod]
        public void GetUserOK()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Cristhian",
                LastName = "Maciel",
                UserName = "Cris",
                Password = "123456",
                Admin = true
            };

            var mock = new Mock<IUserLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Get(user.Id)).Returns(user);

            var mockIDL = new Mock<IIndicatorDisplayLogic>(MockBehavior.Strict);
            var mockIL = new Mock<IIndicatorLogic>(MockBehavior.Strict);

            var controller = new UsersController(mock.Object, mockIDL.Object, mockIL.Object);
            var result = controller.Get(user.Id);

            var createdResult = result as OkObjectResult;
            var model = createdResult.Value as UserModel;

            mock.VerifyAll();

            Assert.AreEqual(user.UserName,model.UserName);
        }


        [TestMethod]
        public void GetNotExistingUser()
        {
            var mock = new Mock<IUserLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Get(It.IsAny<Guid>())).Throws(new BusinessLogicInterfaceException());
            var mockIDL = new Mock<IIndicatorDisplayLogic>(MockBehavior.Strict);
            var mockIL = new Mock<IIndicatorLogic>(MockBehavior.Strict);

            var controller = new UsersController(mock.Object, mockIDL.Object, mockIL.Object);
            var result = controller.Get(Guid.NewGuid());

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }


        [TestMethod]
        public void UpdateUser()
        {
            var model = new UserModel()
            {
                Id = Guid.NewGuid(),
                Name = "Cristhian",
                LastName = "Maciel",
                UserName = "Cris",
                Password = "123456",
                Admin = true
            };

            var mock = new Mock<IUserLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<User>())).Returns(model.ToEntity());
            var mockIDL = new Mock<IIndicatorDisplayLogic>(MockBehavior.Strict);
            var mockIL = new Mock<IIndicatorLogic>(MockBehavior.Strict);

            var controller = new UsersController(mock.Object, mockIDL.Object, mockIL.Object);
            var result = controller.Put(model.Id, model);
            var createdResult = result as OkObjectResult;

            mock.VerifyAll();
        }



        [TestMethod]
        public void DeleteUser()
        {
            var model = new UserModel()
            {
                Id = Guid.NewGuid(),
                Name = "Cristhian",
                LastName = "Maciel",
                UserName = "Cris",
                Password = "123456",
                Admin = true
            };

            var mock = new Mock<IUserLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Remove(It.IsAny<User>()));
            var mockIDL = new Mock<IIndicatorDisplayLogic>(MockBehavior.Strict);
            var mockIL = new Mock<IIndicatorLogic>(MockBehavior.Strict);

            var controller = new UsersController(mock.Object, mockIDL.Object, mockIL.Object);
            var result = controller.Delete(model.Id, model);
            var createdResult = result as OkObjectResult;

            mock.VerifyAll();
        }


    }
}
