using System;
using System.Collections.Generic;

namespace Reports.Domain
{
    public class Indicator
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? GreenConditionId { get; set; }
        public virtual BaseCondition GreenCondition { get; set; }
        public Guid? YellowConditionId { get; set; }
        public virtual BaseCondition YellowCondition { get; set; }
        public Guid? RedConditionId { get; set; }
        public virtual BaseCondition RedCondition { get; set; }

        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }
        public virtual IEnumerable<IndicatorConfig> IndicatorConfigs { get; set; }

        public bool IsValid()
        {
            return Id != null && Name!=null && GreenCondition != null && YellowCondition != null
                && RedCondition != null && GreenCondition.IsValid()
                && YellowCondition.IsValid() && RedCondition.IsValid();
        }
        public string GetGreenResult()
        {
            if (GreenCondition != null && GreenCondition.IsValid())
            {
                return GreenCondition.GetResult(Area.ConnectionString);
            }
            else
            {
                throw new DomainException("Condition is not valid");
            }
        }
        public string GetYellowResult()
        {
            if (YellowCondition != null && YellowCondition.IsValid())
            {
                return YellowCondition.GetResult(Area.ConnectionString);
            }
            else
            {
                throw new DomainException("Condition is not valid");
            }
        }
        public string GetRedResult()
        {
            if (RedCondition != null && RedCondition.IsValid())
            {
                return RedCondition.GetResult(Area.ConnectionString);
            }
            else
            {
                throw new DomainException("Condition is not valid");
            }
        }
        public bool IsGreenOn()
        {
            return GreenCondition.Eval(Area.ConnectionString);
        }
        public bool IsYellowOn()
        {
            return YellowCondition.Eval(Area.ConnectionString);
        }
        public bool IsRedOn()
        {
            return RedCondition.Eval(Area.ConnectionString);
        }
        public Indicator Update(Indicator entity)
        {
            if (entity.Name != null)
            {
                Name = entity.Name;
            }

            if (entity.GreenCondition != null)
            {
                GreenCondition = entity.GreenCondition;
            }

            if (entity.YellowCondition != null)
            {
                YellowCondition = entity.YellowCondition;
            }

            if (entity.RedCondition != null)
            {
                RedCondition = entity.RedCondition;
            }
            
            return this;
        }
    }
            
}