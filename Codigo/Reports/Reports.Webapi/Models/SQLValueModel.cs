using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;
using Reports.Webapi.Parsers;

namespace Reports.Webapi.Models
{
    public class SQLValueModel : ValueModel
    {
        public string Data { get; set; }
        public SQLValueModel() { }
        public SQLValueModel(Value entity)
        {
            SetModel(entity);
        }

        public override Value ToEntity()
        {
            return new SQLValue()
            {
                Id = this.Id,
                Query = this.Data
            };
        }
        protected override ValueModel SetModel(Value entity)
        {
            this.Id = entity.Id;
            this.Data = (entity as SQLValue).Query;
            this.ValueType = ValueModelType.SQL;
            return this;
        }
    }
}
