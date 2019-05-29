using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class IntValue : Value
    {
        public int Data { get; set; }
        

        public override object Eval(string areaConnectionStr)
        {
            return Data;
        }

        public override bool Equal(Value aValue, string areaConnectionStr)
        {
            throw new NotImplementedException();
        }

        public override bool LessThan(Value aValue, string areaConnectionStr)
        {
            throw new NotImplementedException();
        }

        public override bool GreaterThan(Value aValue, string areaConnectionStr)
        {
            throw new NotImplementedException();
        }

        public override bool LessEqualThan(Value aValue, string areaConnectionStr)
        {
            throw new NotImplementedException();
        }

        public override bool GreaterEqualThan(Value aValue, string areaConnectionStr)
        {
            throw new NotImplementedException();
        }
    }
}
