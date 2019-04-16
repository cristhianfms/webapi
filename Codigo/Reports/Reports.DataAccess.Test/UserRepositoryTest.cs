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
            IRepository<User> userRepo = new UserRepository(context);

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
        [ExpectedException(typeof(RepositoryException))]
        public void AddUserSameGuid()
        {   
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<User> userRepo = new UserRepository(context);

            var sameid = new Guid("00000000000000000000000000000001");

            var name = "Santiago";
            var lastName = "Larralde";
            var userName = "Santi1";
            var password = "12345678";
            var rol = User.UserType.M;

            var name2 = "Cristhian";
            var lastName2 = "Maciel";
            var userName2 = "Cris1";
            var password2 = "87654321";
            var rol2 = User.UserType.M;

            userRepo.Add(new User{
                Id = sameid,
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
                Rol = rol,
            }); 

            userRepo.Add(new User{
                Id = sameid,
                Name = name2,
                LastName = lastName2,
                UserName = userName2,
                Password = password2,
                Rol = rol2,
            }); 
        }
    }
}
