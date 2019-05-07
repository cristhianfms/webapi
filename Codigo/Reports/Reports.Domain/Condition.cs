using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class Condition : Component
    {
        public ValueExpression ValueIzq { get; set; }
        public ValueExpression ValueDer { get; set; }
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
    }
}
