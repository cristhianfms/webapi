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

        public bool isValidArea(Area area){
            return (area.Name!=null && area.Name != "" ) && 
            (area.ConnectionString!=null && area.ConnectionString != "") && 
            area.Id !=null && 
            //area.Indicators.Count > 0 && 
            area.AreaManagers.Select(c=>c.AreaId == Id).Count() == 0;
        }
    
    }
}
