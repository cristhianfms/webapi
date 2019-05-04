using System;
using Reports.Domain;
using System.Collections.Generic;
using Reports.BusinessLogic;

namespace Reports.BusinessLogic.Interface
{
    public class IIndicatorLogic
    {
        void Create(Indicator indicator){}
        void Remove(Indicator indicator){}
        void Update(Guid id, Indicator indicator){}
        Indicator Get(Guid id){
            return null;
        }
        List<Indicator> GetAll(){
            return null;
        }
    }
}