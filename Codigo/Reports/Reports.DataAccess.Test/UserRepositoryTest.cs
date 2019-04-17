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

            var users =  userRepo.GetAll().ToList();
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


        [TestMethod]
        public void RemoveUserOk(){
            string contextName = Guid.NewGuid().ToString();
            var context = ContextFactory.GetMemoryContext(contextName);
            IRepository<User> userRepo = new UserRepository(context);
            
            var name = "Santiago";
            var lastName = "Larralde";
            var userName = "Santi1";
            var password = "12345678";
            var rol = User.UserType.M;
            var id = Guid.NewGuid();

            userRepo.Add(new User{
                Id = id,
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
               Rol = rol,
            }); 
            userRepo.Save();

            context = ContextFactory.GetMemoryContext(contextName);
            userRepo = new UserRepository(context);
            userRepo.Remove(new User{
                Id = id,
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
                Rol = rol,
            });
            userRepo.Save();

            var users =  userRepo.GetAll().ToList();
            Assert.AreEqual(users.Count, 0);
        }

 

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void RemoveNotExistingUser(){
            string contextName = Guid.NewGuid().ToString();
            var context = ContextFactory.GetMemoryContext(contextName);
            IRepository<User> userRepo = new UserRepository(context);
            
            var name = "Santiago";
            var lastName = "Larralde";
            var userName = "Santi1";
            var password = "12345678";
            var rol = User.UserType.M;
            var id = Guid.NewGuid();

            userRepo.Remove(new User{
                Id = id,
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
                Rol = rol,
            });
            userRepo.Save();
        }



        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void RemoveNotExistingUser2(){
            string contextName = Guid.NewGuid().ToString();
            var context = ContextFactory.GetMemoryContext(contextName);
            IRepository<User> userRepo = new UserRepository(context);
            
            var name = "Santiago";
            var lastName = "Larralde";
            var userName = "Santi1";
            var password = "12345678";
            var rol = User.UserType.M;
            var id = Guid.NewGuid();

            userRepo.Add(new User{
                Id = id,
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
               Rol = rol,
            }); 
            userRepo.Save();


            var name2 = "Cristhian";
            var lastName2 = "Maciel";
            var userName2 = "Cris";
            var password2 = "87654321";
            var rol2 = User.UserType.M;
            var id2 = Guid.NewGuid();
            
            context = ContextFactory.GetMemoryContext(contextName);
            userRepo = new UserRepository(context);
            userRepo.Remove(new User{
                Id = id2,
                Name = name2,
                LastName = lastName2,
                UserName = userName2,
                Password = password2,
                Rol = rol2,
            });
            userRepo.Save();
        }


        [TestMethod]
        public void UpdateUserOK(){
            string contextName = Guid.NewGuid().ToString();
            var context = ContextFactory.GetMemoryContext(contextName);
            IRepository<User> userRepo = new UserRepository(context);          
            
            var name = "Santiago";
            var lastName = "Larralde";
            var userName = "Santi1";
            var password = "12345678";
            var rol = User.UserType.M;
            var id = Guid.NewGuid();

            User user = new User{
                Id = id,
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
               Rol = rol,
            };

            userRepo.Add(user); 
            userRepo.Save();

            string newPass = "newP@a555";
            User userUpdated = new User{
                Id = id,
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = newPass,
               Rol = rol,
            };
            
            context = ContextFactory.GetMemoryContext(contextName);
            userRepo = new UserRepository(context); 
            userRepo.Update(userUpdated);
            userRepo.Save();
                         
            List<User> users = userRepo.GetAll().ToList();
            Assert.AreEqual(users[0].Password, newPass);
        }

        [TestMethod]
        public void UpdateUserOK2(){
            string contextName = Guid.NewGuid().ToString();
            var context = ContextFactory.GetMemoryContext(contextName);
            IRepository<User> userRepo = new UserRepository(context);          
            
            var name = "Santiago";
            var lastName = "Larralde";
            var userName = "Santi1";
            var password = "12345678";
            var rol = User.UserType.M;
            var id = Guid.NewGuid();

            User user = new User{
                Id = id,
                Name = name,
                LastName = lastName,
                UserName = userName,
                Password = password,
               Rol = rol,
            };

            userRepo.Add(user); 
            userRepo.Save();

            
            context = ContextFactory.GetMemoryContext(contextName);
            userRepo = new UserRepository(context); 
            User userToUpdate = userRepo.Get(id);
            string newPass = "newP@a555";
            userToUpdate.Password = newPass;
            userRepo.Update(userToUpdate);
            userRepo.Save();
            
            List<User> users = userRepo.GetAll().ToList();

            Assert.AreEqual(users[0].Password, newPass);
        }








    }
}
