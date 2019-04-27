using System;
using System.Collections.Generic;
using Reports.BusinessLogic.Interface;
using Reports.Domain;
using Reports.DataAccess.Interface;

namespace Reports.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private IRepository<User> userRepo;
        
        public UserLogic(IRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }        

        public void Create (User usr){
            CheckIfUserIsOK(usr);
            userRepo.Add(usr);
            userRepo.Save();
        }

        public User Get(Guid id)
        {
            try
            {
                return this.userRepo.Get(id);
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
           
        }

        public IEnumerable<User> GetAll()
        {
            return this.userRepo.GetAll();
        }

        public void Remove(User usr)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, User usr)
        {
            throw new NotImplementedException();
        }

        private void CheckIfUserIsOK(User usr)
        {
            if (usr == null || !usr.IsValid())
            {
                throw new BusinessLogicException("User instance is not correct");
            }
        }


    }
}
