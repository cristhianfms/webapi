using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class IndicatorSummaryModel
    {
        public Guid AreaId { get; set; }
        public string AreaName { get; set; }
        public int VisibleIndicators { get; set; }
        public int GreenIndicators { get; set; }
        public int YellowIndicators { get; set; }
        public int RedIndicators { get; set; }
    }
}
