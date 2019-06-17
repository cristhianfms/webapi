using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class IndicatorReportModel : Model<Indicator, IndicatorReportModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AreaId { get; set; }
        public string AreaName { get; set; }

        public IndicatorReportModel() { }

        public IndicatorReportModel(Indicator entity)
        {
            SetModel(entity);
        }


        protected override IndicatorReportModel SetModel(Indicator entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.AreaId = entity.AreaId;
            this.AreaName = entity.Area.Name;
            return this;
        }

        public override Indicator ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
