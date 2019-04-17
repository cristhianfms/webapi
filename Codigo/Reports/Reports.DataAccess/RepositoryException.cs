using System;

namespace Reports.DataAccess
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception inner) :base(message, inner){}
         public RepositoryException(string message) :base(message){}
    }

}