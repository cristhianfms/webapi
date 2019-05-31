using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class Value
    {
        public Guid Id { get; set; }
        public abstract object Eval(string areaConnectionStr);
        public abstract bool IsValid();
        public abstract string GetResult(string areaConnectionStr);
        public abstract bool Equal(Value aValue , string areaConnectionStr);
        public abstract bool LessThan(Value aValue, string areaConnectionStr);
        public abstract bool GreaterThan(Value aValue, string areaConnectionStr);
        public abstract bool LessEqualThan(Value aValue, string areaConnectionStr);
        public abstract bool GreaterEqualThan(Value aValue, string areaConnectionStr);
    }

}
