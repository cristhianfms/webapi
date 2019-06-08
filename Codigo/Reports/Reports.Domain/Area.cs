using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports.Domain
{
    public class Area
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }

        public virtual ICollection<Indicator> Indicators { get; set; }
        public virtual ICollection<AreaUser> AreaUsers { get; set; }
        public Area()
        {
            Indicators = new List<Indicator>();
        }

        public bool IsValidArea(){
            return (this.Name != null && this.Name != "") &&
            (this.ConnectionString != null && this.ConnectionString != "") &&
            this.Id != null;
        }
    }
}
