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
        public List<Indicator> Indicators { get; set; }

        public IEnumerable<AreaManager> AreaManagers { get; set; }

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
