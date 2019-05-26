using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class BaseCondition
    {
        public Guid Id { get; set; }
        public  abstract bool Eval();
        public abstract bool IsValid();
    }
}
