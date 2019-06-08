using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain
{
    public class AreaUser
    {
        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }

        public Guid UserId {get; set; }
        public virtual User User { get; set; }
    }
}
