using System;
using Reports.Domain;
using System.Collections.Generic;

namespace Reports.BusinessLogic.Interface
{
    public interface IUserLogic
    {
        void Create (User usr);
        void Remove(User usr);
        void Update(Guid id, User usr);
        User Get(Guid id);
        IEnumerable<User> GetAll();
    }
}
