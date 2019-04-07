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
            var rol = User.UserType.M;

            userRepo.Add(new User{
                Id = Guid.NewGuid(),
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
                Rol = rol,
            }); 
            userRepo.Save();

            var users =  userRepo.GetAll().ToList().ToList();
            Assert.AreEqual(users[0].Rol, User.UserType.M);
        }


        [TestMethod]
        public void AddAdminUserOK()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            UserRepository userRepo = new UserRepository(context);

            var name = "Santiago";
            var lastName = "Larralde";
            var userName = "Santi1";
            var password = "12345678";
            var rol = User.UserType.A;

            userRepo.Add(new User{
                Id = Guid.NewGuid(),
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
                Rol = rol,
            }); 
            userRepo.Save();

            var users =  userRepo.GetAll().ToList().ToList();
            Assert.AreEqual(users[0].Rol, User.UserType.A);
        }



    }
}
