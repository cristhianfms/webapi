using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class IntValue : ValueExpression
    {
         public int Avalue { get; set; }
        public override string Value()
        {
           return Avalue.ToString();
        }
    }
}
