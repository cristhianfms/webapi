using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Webapi.Models
{
    public class IndicatorResultsModel
    {
        public bool GreenConditionOk { get; set; }
        public bool YellowConditionOk { get; set; }
        public bool RedConditionOk { get; set; }

        public string GreenConditionResult { get; set; } = "";
        public string YellowConditionResult { get; set; } = "";
        public string RedConditionResult { get; set; } = "";
    }
}
