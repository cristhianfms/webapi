using System;
using Reports.Domain;
using System.Collections.Generic;

namespace Reports.BusinessLogic.Interface
{
    public interface IUserLogic
    {
        User Create (User usr);
        void Remove(Guid id);
        User Update(Guid id, User usr);
        User Get(Guid id);
        User SetAdminRole(Guid id);
        User SetManagerRole(Guid id);
        IEnumerable<User> GetAll();
        IEnumerable<IndicatorConfig> GetIndicatorConfigs(Guid userId, Guid areaId);
        IndicatorConfig GetIndicatorConfig(Guid userId, Guid areaId);
        void SetIndicatorPosition(Guid userId, Guid indicatorId, int pos);
        void SetIndicatorVisible(Guid userId, Guid indicatorId, bool visible);
        void SetIndicatorCustomName(Guid userId, Guid indicatorId, string customName);
        IEnumerable<Area> GetManagedAreas(Guid userId);
    }
}
