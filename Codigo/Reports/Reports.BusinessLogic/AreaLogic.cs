using System;
using Reports.Domain;
using Reports.DataAccess.Interface;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Reports.BusinessLogic
{
    public class AreaLogic : IAreaLogic
    {
        private IRepository<Area> areaRepo;
        private IRepository<AreaManager> areaManagerRepo;
        private IRepository<User> userRepo;

        public AreaLogic(IRepository<Area> areaRepo , IRepository<AreaManager> areaManagerRepo
            , IRepository<User> userRepo) {

            this.areaRepo = areaRepo;
            this.areaManagerRepo = areaManagerRepo;
            this.userRepo = userRepo;
        }
        
        public void CreateArea(Area area) {
            try{
                if (area.IsValidArea(area)) {
                    areaRepo.Add(area);
                    areaRepo.Save();
                }
                else { 
                   throw new BusinessLogicException("Invalid area");
                }
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public void RemoveArea(Area area) {
            try {
                 if (area.IsValidArea(area)) {
                    areaRepo.Remove(area);
                    areaRepo.Save();
                }
                else { 
                   throw new BusinessLogicException("Invalid Area");
                }
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }   


        public void UpdateArea(Area area) {
            try {
                 if (area.IsValidArea(area)) {
                    areaRepo.Update(area);
                    areaRepo.Save();
                }
                else { 
                   throw new BusinessLogicException("Invalid Area");
                }
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public Area Get(Guid id){
            try {
                return areaRepo.Get(id);
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public IEnumerable<Area> GetAll(){
            try {
                return areaRepo.GetAll();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public void AddIndicator(Guid areaID, Indicator indicator)
        {
            Area area = Get(areaID);
            area.Indicators.Add(indicator);
            UpdateArea(area);
        }




        public IEnumerable<User> GetManagers(Guid areaId)
        { 
            return areaManagerRepo.GetAll().Where(am => am.AreaId == areaId)
                .Select(c => c.Manager);
        }


        public void AddManager(Guid areaId, Guid managerId)
        {
            try { 
                User manager = userRepo.Get(managerId);
                Area area = areaRepo.Get(areaId);
                CheckUserManager(manager);
                AreaManager areaManager = new AreaManager()
                {
                    AreaId = areaId,
                    Area = area,
                    ManagerId = managerId,
                    Manager = manager
                };
                areaManagerRepo.Add(areaManager);
                areaManagerRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                    throw new BusinessLogicException(e.Message, e);
            }
        }


        public void RemoveManager(Guid areaId, Guid managerId)
        {
            AreaManager areaManager = new AreaManager()
            {
                AreaId = areaId,
                ManagerId = managerId
            };
            areaManagerRepo.Remove(areaManager);
            areaManagerRepo.Save();
        }

        private void CheckUserManager(User user)
        {
            if (user.Admin)
                throw new BusinessLogicException("User must have manager role");
        }


    }
}
