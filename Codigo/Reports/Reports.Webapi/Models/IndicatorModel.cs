using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Webapi.Models
{
    public class IndicatorModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public BaseConditionModel GreenCondition { get; set; }

        public BaseConditionModel YellowCondition { get; set; }

        public BaseConditionModel RedCondition { get; set; }
    }
}
