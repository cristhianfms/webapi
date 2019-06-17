using System;
using Reports.Domain;
using System.Collections.Generic;
using Reports.BusinessLogic;

namespace Reports.BusinessLogic.Interface
{
    public interface IIndicatorLogic
    {
        Indicator Create(Indicator indicator);
        void Remove(Guid id);
        Indicator Update(Indicator indicator);
        Indicator Get(Guid id);
        IEnumerable<Indicator> GetAll();
        bool CheckConditionEval(BaseCondition condition, String connectionStr);
        string GetConditionResult(BaseCondition condition, String connectionStr);
        IEnumerable<IndicatorConfig> GetCustomIndicators(Guid managerId, Guid areaId);

        int CountVisibleIndicators(Guid managerId, Guid areaId);
        int CountRedIndicators(Guid managerId, Guid areaId);
        int CountYellowIndicators(Guid managerId, Guid areaId);
        int CountGreenIndicators(Guid managerId, Guid areaId);
    }
}