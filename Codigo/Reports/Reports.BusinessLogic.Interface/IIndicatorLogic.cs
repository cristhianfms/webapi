using System;
using Reports.Domain;
using System.Collections.Generic;
using Reports.BusinessLogic;

namespace Reports.BusinessLogic.Interface
{
    public interface IIndicatorLogic
    {
        Indicator Create(Indicator indicator);
        void Remove(Indicator indicator);
        void Update(Indicator indicator);
        Indicator Get(Guid id);
        IEnumerable<Indicator> GetAll();
    }
}