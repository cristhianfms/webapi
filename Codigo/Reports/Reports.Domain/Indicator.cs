using System;

namespace Reports.Domain
{
    public class Indicator
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? GreenConditionId { get; set; }
        public virtual BaseCondition GreenCondition { get; set; }

        public Guid?  YellowConditionId { get; set; }
        public virtual BaseCondition YellowCondition { get; set;}

        public Guid? RedConditionId { get; set; }
        public virtual BaseCondition RedCondition { get; set; }

        public bool IsValid()
        {
            return Id != null && GreenCondition != null && YellowCondition != null
                && RedCondition != null; 
        }

    }
}