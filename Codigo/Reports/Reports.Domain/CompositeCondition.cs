using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class CompositeCondition : BaseCondition
    {
        public Guid? IzqId { get; set; }
        public virtual BaseCondition Izq { get; set; }

        public Guid? DerId { get; set; }
        public virtual BaseCondition Der { get; set; }

        public override bool IsValid()
        {
            return Der != null && Izq != null;
        }
    }
}

