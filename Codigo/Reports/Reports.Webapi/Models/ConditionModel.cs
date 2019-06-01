using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class ConditionModel : BaseConditionModel
    {
        public ConditionModel() { }
        public ConditionModel(BaseCondition entity)
        {
            SetModel(entity);
        }

        public ValueModel ValueIzq { get; set; }
        public ValueModel ValueDer { get; set; }
        public string Operator { get; set; }

        public override BaseCondition ToEntity()
        {
            Condition condition = new Condition()
            {
                Id = this.Id,
                ValueDer = this.ValueDer.ToEntity(),
                ValueIzq = this.ValueIzq.ToEntity(),
                Operator = this.Operator,
            };
            return condition;
        }
        protected override BaseConditionModel SetModel(BaseCondition entity)
        {
            this.Id = entity.Id;
            this.ValueDer = ValueModel.ToModel((entity as Condition).ValueDer);
            this.ValueIzq = ValueModel.ToModel((entity as Condition).ValueIzq);
            this.Operator = (entity as Condition).Operator;
            return this;
        }
    }
}
