using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports.DataAccess;
using Reports.DataAccess.Interface;
using Reports.Domain;
using System.Linq;

namespace Reports.DataAccess.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void AddManagerUserOK()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            UserRepository userRepo = new UserRepository(context);

            var name = "Santiago";
            var lastName = "Larralde";
            var userName = "Santi1";
            var password = "12345678";

            userRepo.Add(new User{
                Id = Guid.NewGuid(),
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password
            }); 
            userRepo.Save();

            var users =  userRepo.GetAll().ToList();
            Assert.AreEqual(users.Count, 1);
        }


    }
}
