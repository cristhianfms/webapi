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

        private void CheckIsValid()
        {
            if (IzqId == null || DerId == null)
                throw new DomainException("One of the parts of the condition is empty");
        }
    }
}

