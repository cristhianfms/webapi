﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class StringValue : ValueExpression
    {

        public override string Evaluate()
        {
            return Value;
        }
    }
}
