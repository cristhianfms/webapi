using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Webapi.Models;
using Reports.Domain;

namespace Reports.Webapi.Models.ManagerIndicators
{
    public class CustomIndicatorUpdateModel : Model<IndicatorConfig, CustomIndicatorUpdateModel>
    {
        public Guid Id { get; set; }
        public string CustomName { get; set; }
        public bool Visible { get; set; }
        public int Position { get; set; }

        public CustomIndicatorUpdateModel() { }

        public CustomIndicatorUpdateModel(IndicatorConfig entity)
        {
            SetModel(entity);
        }

        public override IndicatorConfig ToEntity()
        {
            return new IndicatorConfig()
            {
                Id = this.Id,
                CustomName = this.CustomName,
                Visible = this.Visible,
                Position = this.Position
            };
        }

        protected override CustomIndicatorUpdateModel SetModel(IndicatorConfig entity)
        {
            this.Id = entity.Id;
            this.CustomName = entity.CustomName;
            this.Visible = entity.Visible;
            this.Position = entity.Position;
            return this;
        }
    }
}
