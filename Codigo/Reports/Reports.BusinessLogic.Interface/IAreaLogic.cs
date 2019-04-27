using System;
using Reports.Domain;
using System.Collections.Generic;
using Reports.BusinessLogic;

namespace Reports.BusinessLogic.Interface
{
    public class IAreaLogic
    {
        void CreateArea(Area area){}
        void RemoveArea(Area area){}
        void UpdateArea(Guid id, Area area){}
        Area Get(Guid id){
            return null;
        }
        List<Area> GetAll(){
            return null;
        }
    }
}