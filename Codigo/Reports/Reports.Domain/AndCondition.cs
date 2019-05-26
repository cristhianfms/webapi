﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class AndCondition : CompositeCondition
    {
        public override bool Eval()
        {
            return this.Der.Eval() 
                && this.Izq.Eval();
        }
    }
}
