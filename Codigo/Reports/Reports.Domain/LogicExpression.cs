using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class LogicExpression : Component
    {
        public Guid? CompIzqId { get; set; }
        public virtual Component CompIzq { get; set; }
        public Guid? CompDerId { get; set; }
        public virtual Component CompDer { get; set; }

        public override bool IsValid()
        {
            return CompIzq != null && CompDer != null;
        }
    }
}

