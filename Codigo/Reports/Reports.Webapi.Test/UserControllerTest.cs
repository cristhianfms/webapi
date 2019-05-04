using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports.Webapi.Models;
using Reports.Webapi.Controllers;
using Reports.Domain;
using Reports.BusinessLogic.Interface;
using Moq;
using Microsoft.AspNetCore.Mvc;


namespace Reports.Webapi.Test
{
    [TestClass]
    public class UserControllerTest
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
            mock.Setup(m => m.Create(It.IsAny<User>()));

            var controller = new UsersController(mock.Object);

            var result = controller.Post(user);
            var createdResult = result as CreatedAtRouteResult;
            
            mock.VerifyAll();
        }









    }
}
