using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.BusinessLogic.Interface
{
    public class BusinessLogicInterfaceException : Exception
    {
        public BusinessLogicInterfaceException() : base() { }
        public BusinessLogicInterfaceException(string message) : base(message) { }
        public BusinessLogicInterfaceException(string message, Exception inner) : base(message, inner) { }
    }
}
