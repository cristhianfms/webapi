using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;
using Reports.Webapi.Parsers;
using Newtonsoft.Json;


namespace Reports.Webapi.Models
{
    [JsonConverter(typeof(ValueModelJsonConverter))]
    public class ValueModel : Model<Value,ValueModel>
    {
        public Guid Id { get; set; }
        public string ValueType { get; set; }

        public ValueModel() { }
        public ValueModel(Value entity)
        {
            SetModel(entity);
        }
        public override Value ToEntity()
        {
            throw new NotImplementedException();
        }
        protected override ValueModel SetModel(Value entity)
        {
            return DTOConverter.ConvertToValueModel(entity);
        }
    }
}
