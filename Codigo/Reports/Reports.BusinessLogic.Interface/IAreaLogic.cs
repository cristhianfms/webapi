using System;
using Reports.Domain;
using System.Collections.Generic;
using Reports.BusinessLogic;

namespace Reports.BusinessLogic.Interface
{
    public interface IAreaLogic
    {
        Area CreateArea(Area area);
        void RemoveArea(Area area);
        Area UpdateArea(Area area);
        Area Get(Guid id);
        IEnumerable<Area> GetAll();

        IEnumerable<User> GetManagers(Guid areaId);
        void AddManager(Guid areaId, Guid managerId);
        void RemoveManager(Guid areaId, Guid managerId);

        IEnumerable<Indicator> GetIndicators(Guid areaId);
        void AddIndicator(Guid areaId, Guid indicatorId);
        void RemoveIndicator(Guid areaId, Guid indicatorId);
    }
}