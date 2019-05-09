using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public abstract class Component
    {
        public Guid Id { get; set; }

        public abstract bool Evaluete();
        public abstract bool IsValid();
    }
}
