using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class SQLValueModel : ValueModel
    {
        public string Data { get; set; }
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
            return this;
        }
    }
}
