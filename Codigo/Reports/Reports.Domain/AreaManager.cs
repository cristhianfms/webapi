using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class AreaManager
    {
        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }

        public Guid ManagerId { get; set; }
        public virtual User Manager { get; set; }
    }
}
