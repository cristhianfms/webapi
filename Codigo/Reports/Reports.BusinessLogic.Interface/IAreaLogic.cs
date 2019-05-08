using System;
using Reports.Domain;
using System.Collections.Generic;
using Reports.BusinessLogic;

namespace Reports.BusinessLogic.Interface
{
    public interface IAreaLogic
    {
        void CreateArea(Area area);
        void RemoveArea(Area area);
        void UpdateArea(Area area);
        Area Get(Guid id);
        IEnumerable<Area> GetAll();

        IEnumerable<User> GetManagers(Guid areaId);
        void AddManager(Guid areaId, Guid managerId);
        void RemoveManager(Guid areaId, Guid managerId);
    }
}