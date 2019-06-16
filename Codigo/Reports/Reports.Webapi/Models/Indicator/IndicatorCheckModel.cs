using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class IndicatorCheckModel : Model<Indicator, IndicatorCheckModel>
    {
        public Guid AreaId { get; set; }
        public BaseConditionModel GreenCondition { get; set; }

        public BaseConditionModel YellowCondition { get; set; }

        public BaseConditionModel RedCondition { get; set; }

        public IndicatorCheckModel() { }

        public IndicatorCheckModel(Indicator entity)
        {
            SetModel(entity);
        }

        public override Indicator ToEntity()
        {
            Indicator entity = new Indicator();
            if (GreenCondition != null)
            {
                entity.GreenCondition = this.GreenCondition.ToEntity();
            }
            if (YellowCondition != null)
            {
                entity.YellowCondition = this.YellowCondition.ToEntity();
            }
            if (RedCondition != null)
            {
                entity.RedCondition = this.RedCondition.ToEntity();
            }
            return entity;
        }

        protected override IndicatorCheckModel SetModel(Indicator entity)
        {
            this.GreenCondition = BaseConditionModel.ToModel(entity.GreenCondition);
            this.YellowCondition = BaseConditionModel.ToModel(entity.YellowCondition);
            this.RedCondition = BaseConditionModel.ToModel(entity.RedCondition);
            return this;
        }
    }
}
