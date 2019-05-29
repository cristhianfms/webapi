using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class OrCondition : CompositeCondition
    {
        public override bool Eval(string areaConnectionStr)
        {
            return this.Der.Eval(areaConnectionStr)
                || this.Izq.Eval(areaConnectionStr);
        }
    }
}
