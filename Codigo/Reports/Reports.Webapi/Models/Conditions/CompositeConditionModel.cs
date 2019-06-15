using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class CompositeConditionModel : BaseConditionModel
    {
        public BaseConditionModel Izq { get; set; }
        public BaseConditionModel Der { get; set; }
        public string LogicOperator { get; set; }
    }
}
