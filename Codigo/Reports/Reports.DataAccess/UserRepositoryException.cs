using System;

namespace Reports.DataAccess
{
    public class UserRepositoryException : Exception
    {
        public UserRepositoryException(string message, Exception inner) :base(message, inner){}
    }

}