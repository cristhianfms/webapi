using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class OrConditionModel : CompositeConditionModel
    {
        public override BaseCondition ToEntity()
        {
            OrCondition orCondition = new OrCondition()
            {
                Id = this.Id,
                Der = this.Der.ToEntity(),
                Izq = this.Izq.ToEntity()
            };
            return orCondition;
        }

        protected override BaseConditionModel SetModel(BaseCondition entity)
        {
            this.Id = entity.Id;
            this.Der = BaseConditionModel.ToModel((entity as OrCondition).Der);
            this.Izq = BaseConditionModel.ToModel((entity as OrCondition).Izq);
            this.Condition = ConditionType.OR;
            return this;
        }

    }
}
