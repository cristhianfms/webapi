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


        public User Create(User usr) {
            try
            {
                CheckEmtpyUser(usr);
                usr.Id = Guid.NewGuid();
                CheckIfUserIsOK(usr);
                userRepo.Add(usr);
                userRepo.Save();
                return usr;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
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
            try
            {
                return this.userRepo.GetAll();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public void Remove(User usr)
        {
            try
            {
                CheckEmtpyUser(usr);
                CheckIfUserIsOK(usr);
                this.userRepo.Remove(usr);
                this.userRepo.Save();
            }
            catch(RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public User Update(User usr)
        {
            try
            {
                CheckEmtpyUser(usr);
                CheckIfUserIsOK(usr);
                this.userRepo.Update(usr);
                this.userRepo.Save();
                return usr;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        private void CheckIfUserIsOK(User usr)
        {
            if (!usr.IsValid())
            {
                throw new BusinessLogicException("User instance is not correct");
            }
        }


        private void CheckEmtpyUser(User usr)
        {
            if (usr == null)
            {
                throw new BusinessLogicException("Null user instance");
            }
        }
    }
}
