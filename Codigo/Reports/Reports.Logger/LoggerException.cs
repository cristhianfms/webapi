using System;
using System.Collections.Generic;
using System.Text;
using Reports.Logger.Interface;

namespace Reports.Logger
{
    public class LoggerException : ILoggerException
    {
        public LoggerException(string message) : base(message) { }
        public LoggerException(string message, Exception inner) : base(message, inner) { }
    }
}
