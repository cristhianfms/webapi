using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Logger
{
    public class LoggerException : Exception
    {
        public LoggerException(string message) : base(message) { }
        public LoggerException(string message, Exception inner) : base(message, inner) { }
    }
}
