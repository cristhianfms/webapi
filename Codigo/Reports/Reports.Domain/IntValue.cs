using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class IntValue : ValueExpression
    {
        public override string Evaluate()
        {
           return Value.ToString();
        }
    }
}
