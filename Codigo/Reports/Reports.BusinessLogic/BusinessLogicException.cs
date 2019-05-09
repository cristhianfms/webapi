using System;
using System.Collections.Generic;
using System.Text;
using Reports.BusinessLogic.Interface;


namespace Reports.BusinessLogic
{
    public class BusinessLogicException : BusinessLogicInterfaceException
    {
        public BusinessLogicException(string message) : base(message) { }
        public BusinessLogicException(string message, Exception inner) : base(message, inner) { }
    }
}
