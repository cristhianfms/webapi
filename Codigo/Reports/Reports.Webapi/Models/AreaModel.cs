using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;
using System.Linq;


namespace Reports.Webapi.Models
{
    public class AreaModel : Model<Area, AreaModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public List<IndicatorModel> Indicators { get; set; }

        public AreaModel() { }

        public AreaModel(Area entity)
        {
            SetModel(entity);
        }

        public override Area ToEntity()
        {
            return new Area()
            {
                Id = this.Id,
                Name = this.Name,
                ConnectionString = this.ConnectionString,
                Indicators = this.Indicators.ConvertAll(m => m.ToEntity()),
            };
            
        }


        protected override AreaModel SetModel(Area entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.ConnectionString = entity.ConnectionString;
            this.Indicators = entity.Indicators.ConvertAll(e => new IndicatorModel(e));
            return this;
        }
    }
}
