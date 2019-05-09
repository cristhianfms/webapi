using System;
using Reports.Domain;

namespace Reports.BusinessLogic.Interface
{
    public interface ISessionLogic
    {
        bool IsValidToken(string token);

        Guid? CreateToken(string userName, string password);

        bool HasLevel(string token, string role);

        Session GetUser(string token);
    }
}