using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.DataAccess.Interface
{
    public class RepositoryInterfaceException : Exception
    {
        public RepositoryInterfaceException(string message) : base(message) { }
        public RepositoryInterfaceException(string message, Exception inner) : base(message, inner) { }
    }
}
