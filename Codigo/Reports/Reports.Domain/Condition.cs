using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class Condition : BaseCondition
    {
        public Guid? ValueIzqId { get; set; }
        public virtual Value ValueIzq { get; set; }

        public Guid? ValueDerId { get; set; }
        public virtual Value ValueDer { get; set; }

        public String Operator {get;set;}


        public override bool Eval(string areaConnectionStr)
        {
            if(Operator == "=")
            {
                return ValueIzq.Equal(ValueDer, areaConnectionStr);
            }
            else if (Operator == "<")
            {
                return ValueIzq.LessThan(ValueDer, areaConnectionStr);

            }
            else if (Operator == ">")
            {
                return ValueIzq.GreaterThan(ValueDer, areaConnectionStr);

            }
            else if (Operator == "<=")
            {
                return ValueIzq.LessEqualThan(ValueDer, areaConnectionStr);
            }
            else if (Operator == ">=")
            {
                return ValueIzq.GreaterEqualThan(ValueDer, areaConnectionStr);
            }
            return false;
        }
        
        public override bool IsValid()
        {
            return ValueIzq != null && ValueDer != null;
        }
    }
}
