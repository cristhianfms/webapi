using System;
using System.Collections.Generic;

namespace Reports.Domain
{
    public class IndicatorConfig
    { 
        public Guid Id { get; set; }

        public Guid IndicatorId { get; set; }
        public virtual Indicator Indicator { get; set; }

        public Guid ManagerId { get; set; }
        public virtual User Manager { get; set; }
               

        public int Position { get; set; }
        public bool Visible { get; set; }
        public string CustomName { get; set; }
    }
}
