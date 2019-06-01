using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Webapi.Models
{
    public class ModelException : Exception
    {
        public ModelException() : base() { }
        public ModelException(string message) : base(message) { }
        public ModelException(string message, Exception inner) : base(message, inner) { }
    }
}
