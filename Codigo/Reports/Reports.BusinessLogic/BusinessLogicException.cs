﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.BusinessLogic
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message) : base(message) { }
        public BusinessLogicException(string message, Exception inner) : base(message, inner) { }
    }
}