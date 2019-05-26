using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class StringValue : Value
    {
        public string Data { get; set; }
        public override string Eval()
        {
            return Data;
        }

        public override string Display()
        {
            return Data;
        }
    }
}
