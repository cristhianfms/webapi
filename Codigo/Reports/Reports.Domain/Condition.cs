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


        public override bool Eval()
        {
            if(Operator == "=")
            {
                return ValueIzq.Eval() == ValueDer.Eval();
            }
            else if (Operator == "<")
            {
                return ValueIzq.Eval().CompareTo(ValueDer.Eval()) < 0;
                
            }
            else if (Operator == ">")
            {
                return ValueIzq.Eval().CompareTo(ValueDer.Eval()) > 0;
            }
            else if (Operator == "<=")
            {
                return ValueIzq.Eval().CompareTo(ValueDer.Eval()) <= 0;
            }
            else if (Operator == ">=")
            {
                return ValueIzq.Eval().CompareTo(ValueDer.Eval()) >= 0;
            }
            return false;
        }
        
        public override bool IsValid()
        {
            return ValueIzq != null && ValueDer != null;
        }
    }
}
