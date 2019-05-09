using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class IndicatorDetailModel
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public bool IsON { get; set; }
        public string ConditionDetails { get; set; }
    }
}
