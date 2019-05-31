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
                && RedCondition != null && GreenCondition.IsValid()
                && YellowCondition.IsValid() && RedCondition.IsValid();
        }
        public string GetGreenResult(string areaConnectionStr)
        {
            if (GreenCondition != null && GreenCondition.IsValid())
            {
                return GreenCondition.GetResult(areaConnectionStr);
            }
            else
            {
                throw new DomainException("Condition is not valid");
            }
        }
        public string GetYellowResult(string areaConnectionStr)
        {
            if (YellowCondition != null && YellowCondition.IsValid())
            {
                return YellowCondition.GetResult(areaConnectionStr);
            }
            else
            {
                throw new DomainException("Condition is not valid");
            }
        }
        public string GetRedResult(string areaConnectionStr)
        {
            if (RedCondition != null && RedCondition.IsValid())
            {
                return RedCondition.GetResult(areaConnectionStr);
            }
            else
            {
                throw new DomainException("Condition is not valid");
            }
        }
    }
}