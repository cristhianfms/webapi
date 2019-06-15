using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;
using Reports.Webapi.Parsers;

namespace Reports.Webapi.Models
{
    public class BoolValueModel : ValueModel
    {
        public bool Data { get; set; }

        public BoolValueModel() { }
        public BoolValueModel(Value entity)
        {
            SetModel(entity);
        }

        public override Value ToEntity()
        {
            return new BoolValue()
            {
                Id = this.Id,
                Data = this.Data
            };
        }
        protected override ValueModel SetModel(Value entity)
        {
            this.Id = entity.Id;
            this.Data = (entity as BoolValue).Data;
            this.ValueType = ValueModelType.BOOL;
            return this;
        }
    }
}
