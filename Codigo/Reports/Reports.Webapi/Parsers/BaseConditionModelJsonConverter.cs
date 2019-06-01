using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Reports.Webapi.Models;

namespace Reports.Webapi.Parsers
{
    public class BaseConditionModelJsonConverter : JsonCreationConverter<BaseConditionModel>
    {
        protected override BaseConditionModel Create(Type objectType, JObject jObject)
        {

            if (jObject == null)
            {
                throw new ArgumentNullException("jObject");
            }
            if (jObject["Operator"] != null)
            {
                return new ConditionModel();
            }
            if (jObject["LogicOperator"] != null)
            {
                var logicOperator = jObject["LogicOperator"].Value<string>();
                if (logicOperator == LogicType.AND)
                    return new AndConditionModel();
                else if (logicOperator == LogicType.OR)
                    return new OrConditionModel();
            }
            return new BaseConditionModel();
        }
    }
}
