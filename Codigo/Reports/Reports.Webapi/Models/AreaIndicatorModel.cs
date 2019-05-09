using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;
using System.Linq;


namespace Reports.Webapi.Models
{
    public class AreaIndicatorModel : Model<Indicator, AreaIndicatorModel>
    {
        public Guid IndicatorId { get; set; }

        public override Indicator ToEntity()
        {
            return new Indicator
            {
                Id = this.IndicatorId
            };
        }

        protected override AreaIndicatorModel SetModel(Indicator entity)
        {
            return new AreaIndicatorModel
            {
                IndicatorId = entity.Id
            };
        }
    }
}
