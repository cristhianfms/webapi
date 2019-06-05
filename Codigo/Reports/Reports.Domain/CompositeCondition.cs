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
            return Izq != null && Der != null && Izq.IsValid() && Der.IsValid() ;
        }

        public override void Update(BaseCondition entity)
        {
            if((entity as CompositeCondition).Izq != null)
            {
                this.Update((entity as CompositeCondition).Izq);
            }
            if ((entity as CompositeCondition).Der != null)
            {
                this.Update((entity as CompositeCondition).Der);
            }
        }
    }
}

