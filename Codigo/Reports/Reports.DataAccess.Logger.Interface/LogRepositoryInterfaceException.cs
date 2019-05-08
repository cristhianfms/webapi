using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.DataAccess.Logger.Interface
{
    public class LogRepositoryInterfaceException : Exception
    {
        public LogRepositoryInterfaceException(string message) : base(message) { }
        public LogRepositoryInterfaceException(string message, Exception inner) : base(message, inner) { }
    }
}