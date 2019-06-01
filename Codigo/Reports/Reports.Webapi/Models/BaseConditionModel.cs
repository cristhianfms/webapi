using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class BaseConditionModel : Model<BaseCondition, BaseConditionModel>
    {
        public Guid Id { get; set; }

        public BaseConditionModel() { }
        public BaseConditionModel(BaseCondition entity)
        {
            SetModel(entity);
        }
        public override BaseCondition ToEntity()
        {
            throw new NotImplementedException();
        }
        protected override BaseConditionModel SetModel(BaseCondition entity)
        {
            throw new NotImplementedException();
        }
    }
}
