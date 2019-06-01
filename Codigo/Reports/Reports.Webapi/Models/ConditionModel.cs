using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class ConditionModel : BaseConditionModel
    {
        public ValueModel ValueIzq { get; set; }
        public ValueModel ValueDer { get; set; }
        public string Condition { get; set; }
    }
}
