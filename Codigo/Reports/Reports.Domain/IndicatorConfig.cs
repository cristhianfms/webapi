using System;
using System.Collections.Generic;

namespace Reports.Domain
{
    public class IndicatorConfig
    { 
        public Guid IndicatorConfigId { get; set; }

        public Guid IndicatorId { get; set; }
        public virtual Indicator Indicator { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }


        public string CustomName { get; set; }
        public int Position { get; set; }
        public bool Visible { get; set; }
    }
}
