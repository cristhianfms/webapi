using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class BaseCondition
    {
        public Guid Id { get; set; }
        public  abstract bool Eval(string areaConnectionStr);
        public abstract string GetResult(string areaConnectionStr);
        public abstract bool IsValid();
        public abstract void Update(BaseCondition entity);
    }
}
