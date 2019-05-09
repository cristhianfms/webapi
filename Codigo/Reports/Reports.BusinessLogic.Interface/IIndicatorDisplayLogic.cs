using System;
using Reports.Domain;
using System.Collections.Generic;

namespace Reports.BusinessLogic.Interface
{
    public interface IIndicatorDisplayLogic
    {
        void Create (IndicatorDisplay indDisplay);
        void Remove(IndicatorDisplay indDisplay);
        void Update(IndicatorDisplay indDisplay);
        IndicatorDisplay Get(Guid id);
        IEnumerable<IndicatorDisplay> GetAll();
        IEnumerable<IndicatorDisplay> GetAllByManagerId(Guid managerId);
    }
}
