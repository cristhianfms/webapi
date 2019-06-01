using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class StringValueModel : ValueModel
    {
        public string Data { get; set; }

        public IntValueModel() { }
        public IntValueModel(Value entity)
        {
            SetModel(entity);
        }

        public override Value ToEntity()
        {
            return new StringValue()
            {
                Id = this.Id,
                Data = this.Data
            };
        }
        protected override ValueModel SetModel(Value entity)
        {
            this.Id = entity.Id;
            this.Data = (entity as StringValue).Data;
            return this;
        }
    }
}
