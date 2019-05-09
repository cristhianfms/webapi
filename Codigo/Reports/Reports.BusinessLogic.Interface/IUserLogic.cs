using System;
using Reports.Domain;
using System.Collections.Generic;

namespace Reports.BusinessLogic.Interface
{
    public interface IUserLogic
    {
        User Create (User usr);
        void Remove(User usr);
        User Update(User usr);
        User Get(Guid id);
        IEnumerable<User> GetAll();
    }
}
