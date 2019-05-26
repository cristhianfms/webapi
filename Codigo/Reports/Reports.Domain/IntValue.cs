using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class IntValue : Value
    {
        public int Data { get; set; }
        public override string Eval()
        {
           return Data.ToString();
        }

        public override string Display()
        {
            return Data.ToString();
        }
    }
}
