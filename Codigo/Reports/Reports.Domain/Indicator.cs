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

        public string GetGreenResult()
        {
            if (GreenCondition != null)
            {
                return GreenCondition.GetResult();
            }
            else
            {
                throw new DomainException("No green condition have been set");
            }
        }

        public string GetYellowResult()
        {
            if(YellowCondition != null)
            {
                return YellowCondition.GetResult();
            }
            else
            {
                throw new DomainException("No yellow condition have been set");
            }
        }

        public string GetRedResult()
        {
            if (RedCondition != null)
            {
                return RedCondition.GetResult();
            }
            else
            {
                throw new DomainException("No red condition have been set");
            }
        }
    }
}