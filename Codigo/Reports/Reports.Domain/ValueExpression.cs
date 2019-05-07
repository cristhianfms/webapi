using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class ValueExpression
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public abstract string Evaluate();
    }
}
