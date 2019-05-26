using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class Value
    {
        public Guid Id { get; set; }
        public abstract string Eval();

        public abstract string Display();
    }
}
