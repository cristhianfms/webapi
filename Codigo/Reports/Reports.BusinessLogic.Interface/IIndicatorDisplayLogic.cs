using System;
using Reports.Domain;
using System.Collections.Generic;

namespace Reports.BusinessLogic.Interface
{
    public interface IndicatorDisplayLogic
    {
        void Create (IndicatorDisplay indDisplay);
        void Remove(IndicatorDisplay indDisplay);
        void Update(IndicatorDisplay indDisplay);
        User Get(Guid id);
        IEnumerable<IndicatorDisplay> GetAll();
    }
}
