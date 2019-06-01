using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class AndConditionModel : CompositeConditionModel
    {
        public override BaseCondition ToEntity()
        {
            AndCondition andCondition = new AndCondition()
            {
                Id = this.Id,
                Der = this.Der.ToEntity(),
                Izq = this.Izq.ToEntity(),
            };
            return andCondition;
        }

        protected override BaseConditionModel SetModel(BaseCondition entity)
        {
            this.Id = entity.Id;
            this.Der = BaseConditionModel.ToModel(( entity as AndCondition).Der);
            this.Izq = BaseConditionModel.ToModel((entity as AndCondition).Izq);
            this.LogicOperator = ConditionType.AND;
            return this;
        }

    }
}
