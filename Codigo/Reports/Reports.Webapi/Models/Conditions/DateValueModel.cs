using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;
using Reports.Webapi.Parsers;

namespace Reports.Webapi.Models
{
    public class DateValueModel : ValueModel
    {
        public DateTime Data { get; set; }

        public DateValueModel() { }
        public DateValueModel(Value entity)
        {
            SetModel(entity);
        }

        public override Value ToEntity()
        {
            try
            {
                return new DateValue()
                {
                    Id = this.Id,
                    Data = Data
                };
            }
            catch
            {
                throw new ModelException("Could not parse date");
            }
        }
        protected override ValueModel SetModel(Value entity)
        {
            this.Id = entity.Id;
            this.Data = (entity as DateValue).Data;
            this.ValueType = ValueModelType.DATE;
            return this;
        }
    }
}
