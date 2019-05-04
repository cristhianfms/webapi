using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class IndicatorModel : Model<Indicator, IndicatorModel>
    {
        public IndicatorModel() { }

        public IndicatorModel(Indicator entity)
        {
            SetModel(entity);
        }

        public override Indicator ToEntity()
        {
            throw new NotImplementedException();
        }

        protected override IndicatorModel SetModel(Indicator entity)
        {
            throw new NotImplementedException();
        }
    }
}
