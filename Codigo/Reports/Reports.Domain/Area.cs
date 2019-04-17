using System;
using System.Collections.Generic;

namespace Reports.Domain
{
    public class Area
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Managers { get; set; }
        public string ConnectionString { get; set; }
        public List<Indicator> Indicators { get; set; }
    
    }
}
