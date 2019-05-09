using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class LogicExpression : Component
    {
        public virtual Component CompIzq { get; set; }
        public virtual Component CompDer { get; set; }

        public override bool IsValid()
        {
            return CompIzq != null && CompDer != null;
        }
    }
}
