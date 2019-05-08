using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class AreaManager
    {
        public Guid AreaId { get; set; }
        public Area Area { get; set; }

        public Guid ManagerId { get; set; }
        public User Manager { get; set; }
    }
}
