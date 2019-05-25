using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class Condition : Component
    {
        public Guid? ValueIzqId { get; set; }
        public virtual ValueExpression ValueIzq { get; set; }

        public Guid? ValueDerId { get; set; }
        public virtual ValueExpression ValueDer { get; set; }

        public String Operation {get;set;}

        public override bool Evaluete()
        {
            if(Operation == "=")
            {
                return ValueIzq.Evaluate() == ValueDer.Evaluate();
            }
            else if (Operation == "<")
            {
                return ValueIzq.Evaluate().CompareTo(ValueDer.Evaluate()) < 0;
            }
            else if (Operation == ">")
            {
                return ValueIzq.Evaluate().CompareTo(ValueDer.Evaluate()) > 0;
            }
            else if (Operation == "<=")
            {
                return ValueIzq.Evaluate().CompareTo(ValueDer.Evaluate()) <= 0;
            }
            else if (Operation == ">=")
            {
                return ValueIzq.Evaluate().CompareTo(ValueDer.Evaluate()) >= 0;
            }
            return true;
        }
        
        public override bool IsValid()
        {
            return ValueIzq != null && ValueDer != null;
        }
    }
}
