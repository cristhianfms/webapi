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
        public override string GetResult(string areaConnectionStr)
        {
            return Data.ToString();
        }
        public override bool Equal(Value aValue, string areaConnectionStr)
        {
            int otherInt = (int)aValue.Eval(areaConnectionStr);
            return Data == otherInt;
        }
        public override bool LessThan(Value aValue, string areaConnectionStr)
        {
            int otherInt = (int)aValue.Eval(areaConnectionStr);
            return Data < otherInt;
        }
        public override bool GreaterThan(Value aValue, string areaConnectionStr)
        {
            int otherInt = (int)aValue.Eval(areaConnectionStr);
            return Data > otherInt;
        }
        public override bool LessEqualThan(Value aValue, string areaConnectionStr)
        {
            int otherInt = (int)aValue.Eval(areaConnectionStr);
            return Data <= otherInt;
        }
        public override bool GreaterEqualThan(Value aValue, string areaConnectionStr)
        {
            int otherInt = (int)aValue.Eval(areaConnectionStr);
            return Data >= otherInt;
        }


    }
}
