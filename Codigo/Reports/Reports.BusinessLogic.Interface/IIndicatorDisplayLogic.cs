using System;
using Reports.Domain;
using System.Collections.Generic;

namespace Reports.BusinessLogic.Interface
{
    public interface IIndicator_ManagerLogic
    {
        void Create (Indicator_Manager indDisplay);
        void Remove(Indicator_Manager indDisplay);
        void Update(Indicator_Manager indDisplay);
        Indicator_Manager Get(Guid id);
        IEnumerable<Indicator_Manager> GetAll();
        IEnumerable<Indicator_Manager> GetAllByManagerId(Guid managerId);
    }
}
