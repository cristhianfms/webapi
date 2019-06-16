using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class IndicatorModel : Model<Indicator, IndicatorModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BaseConditionModel GreenCondition { get; set; }

        public BaseConditionModel YellowCondition { get; set; }

        public BaseConditionModel RedCondition { get; set; }

        public IndicatorModel() { }

        public IndicatorModel(Indicator entity)
        {
            SetModel(entity);
        }

        public override Indicator ToEntity()
        {
            return new Indicator()
            {
                Id = this.Id,
                Name = this.Name,
                GreenCondition = this.GreenCondition.ToEntity(),
                YellowCondition = this.YellowCondition.ToEntity(),
                RedCondition = this.RedCondition.ToEntity(),
            };
        }

        protected override IndicatorModel SetModel(Indicator entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.GreenCondition = BaseConditionModel.ToModel(entity.GreenCondition);
            this.YellowCondition = BaseConditionModel.ToModel(entity.YellowCondition);
            this.RedCondition = BaseConditionModel.ToModel(entity.RedCondition);
            return this;
        }
    }
}
