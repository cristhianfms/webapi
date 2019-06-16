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
    }
}