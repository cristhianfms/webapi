using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;
using Reports.Webapi.Parsers;
using Newtonsoft.Json;

namespace Reports.Webapi.Models
{
    [JsonConverter(typeof(BaseConditionModelJsonConverter))]
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
