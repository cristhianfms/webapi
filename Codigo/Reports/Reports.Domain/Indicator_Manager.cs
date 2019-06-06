using System;
using System.Collections.Generic;

namespace Reports.Domain
{
    public class Indicator_Manager
    { 
        public Guid Id { get; set; }
        public Guid ManagerId { get; set; }
        public virtual Guid User { get; set; }
        public Guid IndicatorId { get; set; }
        public virtual Indicator Indicator { get; set; }
        public int Position { get; set; }
        public bool Visible { get; set; }
        public string CustomName { get; set; }
    }
}
