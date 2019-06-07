using System;
using Reports.Domain;
using System.Collections.Generic;
using Reports.Domain;

namespace Reports.BusinessLogic.Interface
{
    public interface IIndicator_ManagerLogic
    {
        void Create (Indicator_Manager entity);
        void Remove(Indicator_Manager entity);
        void Update(Guid indicatorId, Guid managerId, Indicator_Manager entity);
        Indicator_Manager Get(Guid indicatorId, Guid managerId);
        IEnumerable<Indicator_Manager> GetIndicators_ManagerByArea(Guid managerId, Guid areaId);
    }
}
