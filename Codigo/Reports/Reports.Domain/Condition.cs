using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public enum Comparator
    {
        equal, less, greater, lessEqual, greatEqual
    };


    public class Condition : Component
    {
        public ValueExpression ValueIzq { get; set; }
        public ValueExpression ValueDer { get; set; }
        public Comparator Operation {get;set;}

        public override bool Evaluete()
        {
            if(Operation == Comparator.equal)
            {
                return ValueIzq.Value() == ValueDer.Value();
            }
            else if (Operation == Comparator.less)
            {
                return ValueIzq.Value().CompareTo(ValueDer.Value()) < 0;
            }
            else if (Operation == Comparator.greater)
            {
                return ValueIzq.Value().CompareTo(ValueDer.Value()) > 0;
            }
            else if (Operation == Comparator.lessEqual)
            {
                return ValueIzq.Value().CompareTo(ValueDer.Value()) <= 0;
            }
            else if (Operation == Comparator.greatEqual)
            {
                return ValueIzq.Value().CompareTo(ValueDer.Value()) >= 0;
            }
            return true;
        }
    }
}
