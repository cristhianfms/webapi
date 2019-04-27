using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class LogicAnd : LogicExpression
    {
        public override bool Evaluete()
        {
            return this.CompDer.Evaluete() 
                && this.CompIzq.Evaluete();
        }
    }
}
