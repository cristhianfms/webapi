using System;
using System.Collections.Generic;

namespace Reports.Domain
{
    public class IndicatorDisplay
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AreaId { get; set; }
        public int Orden { get; set; }
        public bool Visible { get; set; }
    }
}
