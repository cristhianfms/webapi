using System;
using Reports.Domain;
using System.Collections.Generic;
using Reports.BusinessLogic;

namespace Reports.BusinessLogic.Interface
{
    public interface ISessionLogic
    {
        Guid? CreateToken(Guid userId, string password);
        //void Remove(Session sesion);
        //void Update(Session sesion);
        //Session Get(Guid id);
        //IEnumerable<Session> GetAll();
        User GetUser(string token);
       
    }
}