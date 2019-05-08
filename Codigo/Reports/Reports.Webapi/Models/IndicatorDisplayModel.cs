using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;
using System.Linq;


namespace Reports.Webapi.Models
{
    public class IndicatorDisplayModel : Model<IndicatorDisplayModel, IndicatorDisplayModel>
    {
         public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AreaId { get; set; }
        public int Orden { get; set; }
        public bool Visible { get; set; }

        public IndicatorDisplayModel() { }

        public IndicatorDisplayModel(IndicatorDisplayModel entity)
        {
            SetModel(entity);
        }

        public override IndicatorDisplayModel ToEntity()
        {
            return new IndicatorDisplayModel()
            {
                Id = this.Id,
                UserId = this.UserId,
                AreaId = this.AreaId,
                Orden = this.Orden,
                Visible = this.Visible
            };
        }

        protected override IndicatorDisplayModel SetModel(IndicatorDisplayModel entity)
        {
            this.Id = entity.Id;
            this.UserId = entity.UserId;
            this.AreaId = entity.AreaId;
            this.Orden = entity.Orden;
            this.Visible = entity.Visible;
            return this;
        }
    }
}
