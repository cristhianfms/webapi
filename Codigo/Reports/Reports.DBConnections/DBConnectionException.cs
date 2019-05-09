using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.DBConnections
{
    public class DBConnectionException : Exception
    {
        public DBConnectionException() : base() { }
        public DBConnectionException(string message) : base(message) { }
        public DBConnectionException(string message, Exception inner) : base(message, inner) { }
    }
}
