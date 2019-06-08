using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.Domain;
using Reports.Webapi.Models;

namespace Reports.Webapi.Models.ManagerIndicators
{
    public class ManagerAreaModel : Model<Area, ManagerAreaModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CustomIndicatorGetModel> Indicators { get; set; }

        public ManagerAreaModel() { }
        public ManagerAreaModel(Area entity)
        {
            SetModel(entity);
        }

        public override Area ToEntity()
        {
            return new Area()
            {
                Id = this.Id,
                Name = this.Name,
            };
        }

        protected override ManagerAreaModel SetModel(Area entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            return this;
        }
    }
}
