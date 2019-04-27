using System;
using Reports.DataAccess.Interface;

namespace Reports.DataAccess
{
    public class RepositoryException : RepositoryInterfaceException
    {
        public RepositoryException(string message): base(message){}
        public RepositoryException(string message, Exception inner) :base(message, inner){}
        
    }

}