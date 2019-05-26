using System;

namespace Reports.Domain
{
    public class Indicator
    {
        public Guid Id { get; set; }
        public string Color { get; set; }

        public Guid? ConditionId { get; set; }
        public virtual BaseCondition Condition { get; set;}

        public bool IsValid()
        {
            return Id != null && Color != null && Color != "" && Condition != null 
                && Condition.IsValid();
        }

        public bool IsTurnON()
        {
            return Condition.Eval();
        }
    }
}