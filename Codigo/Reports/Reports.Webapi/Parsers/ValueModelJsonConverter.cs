using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reports.Webapi.Models;

namespace Reports.Webapi.Parsers
{
    public class ValueModelJsonConverter : JsonCreationConverter<ValueModel>
    {
        protected override ValueModel Create(Type objectType, JObject jObject)
        {
            if (jObject == null)
            {
                throw new ArgumentNullException("jObject");
            }

            var valueType = jObject["ValueType"].Value<string>();
            ValueModel valueModel = new ValueModel();
            switch (valueType)
            {
                case ValueType.Int:
                    valueModel = new IntValueModel();break;
                case ValueType.SQL:
                    valueModel = new SQLValueModel();break;
                case ValueType.String:
                    valueModel = new StringValueModel();break;
                default:
                    throw new ModelException("Can not parse value type");
            }
            return valueModel;
        }
    }
}
