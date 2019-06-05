using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;
using System.Linq;


namespace Reports.Webapi.Models
{
    public class IndicatorDisplayModel : Model<Indicator_Manager, IndicatorDisplayModel>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AreaId { get; set; }
        public int Orden { get; set; }
        public bool Visible { get; set; }
        public bool IsTurnON { get; set; }

        public IndicatorDisplayModel() { }

        public IndicatorDisplayModel(Indicator_Manager entity)
        {
            SetModel(entity);
        }

        public override Indicator_Manager ToEntity()
        {
            return new Indicator_Manager()
            {
            };
        }

        protected override IndicatorDisplayModel SetModel(Indicator_Manager entity)
        {

            return this;
        }
    }
}
