using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;
using System.Linq;


namespace Reports.Webapi.Models
{
    public class AreaManagerModel
    {
        public Guid AreaId { get; set; }
        public Guid ManagerId { get; set; }
    }
}
