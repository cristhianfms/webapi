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
            UserValidation.IsValidUser(usr);
            userRepo.Add(usr);
            userRepo.Save();
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(User usr)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, User usr)
        {
            throw new NotImplementedException();
        }
    }
}
