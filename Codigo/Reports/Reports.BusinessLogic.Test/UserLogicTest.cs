using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports.Domain;
using Reports.DataAccess;
using Reports.DataAccess.Interface;
using System;
using Moq;

namespace Reports.BusinessLogic.Test
{
    [TestClass]
    public class UnitTest1
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
                Rol = User.UserType.M
            };

            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            userLogic.Create(user);

            mock.VerifyAll();
        }
    }
}
