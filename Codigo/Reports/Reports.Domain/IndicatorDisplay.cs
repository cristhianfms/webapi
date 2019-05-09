﻿using System;
using System.Collections.Generic;

namespace Reports.Domain
{
    public class IndicatorDisplay
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual Guid User { get; set; }

        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }

        public Guid IndicatorId { get; set; }
        public virtual Indicator Indicator { get; set; }

        public int Orden { get; set; }

        public bool Visible { get; set; }
    }
}
