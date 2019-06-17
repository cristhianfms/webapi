using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Logger.Interface
{
    public class ILoggerException : Exception
    {
        public ILoggerException(string message) : base(message) { }
        public ILoggerException(string message, Exception inner) : base(message, inner) { }
    }
}
