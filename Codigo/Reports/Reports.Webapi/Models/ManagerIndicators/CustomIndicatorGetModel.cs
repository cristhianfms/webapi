using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Webapi.Models;
using Reports.Domain;

namespace Reports.Webapi.Models.ManagerIndicators
{
    public class CustomIndicatorGetModel : Model<IndicatorConfig, CustomIndicatorGetModel>
    {
        public Guid AreaId { get; set; }
        public string AreaName { get; set; }
        public Guid Id { get; set; }
        public string CustomName { get; set; }
        public string CurrentColor { get; set; }
        public string GreenResult { get; set; }
        public string YellowResult { get; set; }
        public string RedResult { get; set; }
        public bool Visible { get; set; }
        public int Position { get; set; }

        public CustomIndicatorGetModel() { }
        public CustomIndicatorGetModel(IndicatorConfig entity)
        {
            SetModel(entity);
        }
        public override IndicatorConfig ToEntity()
        {
            return new IndicatorConfig();
        }
        protected override CustomIndicatorGetModel SetModel(IndicatorConfig entity)
        {
            this.AreaId = entity.Indicator.AreaId;
            this.AreaName = entity.Indicator.Area.Name;
            this.Id = entity.Indicator.Id;
            this.CustomName = entity.CustomName;
            this.Visible = entity.Visible;
            this.Position = entity.Position;
            this.GreenResult = entity.Indicator.GetGreenResult();
            this.YellowResult = entity.Indicator.GetYellowResult();
            this.RedResult = entity.Indicator.GetRedResult();
            this.CurrentColor = GetCurrentColor(entity.Indicator);
            return this;
        }
        public string GetCurrentColor(Indicator indicator)
        {
            try { 
                if (indicator.IsGreenOn())
                {
                    return ConditionColor.GREEN;
                }
                else if (indicator.IsYellowOn())
                {
                    return ConditionColor.YELLOW;
                }
                else if (indicator.IsRedOn())
                {
                    return ConditionColor.RED;
                }
                return ConditionColor.GREEN;
            }
            catch (DomainException e)
            {
                return "";
            }
        }

    }
}
