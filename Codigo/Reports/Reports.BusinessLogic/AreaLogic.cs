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
        private IRepository<Indicator> indicatorRepo;

        public AreaLogic(IRepository<Area> areaRepo , IRepository<AreaManager> areaManagerRepo
            , IRepository<User> userRepo, IRepository<Indicator> indicatorRepo) {

            this.areaRepo = areaRepo;
            this.areaManagerRepo = areaManagerRepo;
            this.userRepo = userRepo;
            this.indicatorRepo = indicatorRepo;
        }
        
        public Area CreateArea(Area area) {
            try
            {
                CheckEmtpyArea(area);
                area.Id = new Guid();
                CheckIfAreaOK(area);
                areaRepo.Add(area);
                areaRepo.Save();
                return area;

            }catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }


        public void RemoveArea(Area area) {
            try {
                CheckEmtpyArea(area);
                CheckIfAreaOK(area);
                areaRepo.Remove(area);
                areaRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }   


        public Area UpdateArea(Area area) {
            try
            {
                CheckEmtpyArea(area);
                CheckIfAreaOK(area);
                areaRepo.Update(area);
                areaRepo.Save();
                return area;
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


        public IEnumerable<User> GetManagers(Guid areaId)
        {
            try
            {
                return areaManagerRepo.GetAll().Where(am => am.AreaId == areaId)
                .Select(c => c.Manager);
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }


        public void AddManager(Guid areaId, Guid managerId)
        {
            try { 
                User manager = userRepo.Get(managerId);
                Area area = areaRepo.Get(areaId);
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
            try
            {
                AreaManager areaManager = new AreaManager()
                {
                    AreaId = areaId,
                    ManagerId = managerId
                };
                areaManagerRepo.Remove(areaManager);
                areaManagerRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }


        public IEnumerable<Indicator> GetIndicators(Guid areaId)
        {
            try
            {
                Area area = areaRepo.Get(areaId);
                return area.Indicators;
            }catch(RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message);
            }
        }


        public void AddIndicator(Guid areaId, Guid indicatorId)
        {
            try
            {
                Area area = areaRepo.Get(areaId);
                Indicator indicator = indicatorRepo.Get(indicatorId);
                indicator.Component.Area = area;
                area.Indicators.Add(indicator);
                areaRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message);
            }
        }


        public void RemoveIndicator(Guid areaId, Guid indicatorId)
        {
            try
            {
                Area area = areaRepo.Get(areaId);
                Indicator indicator = indicatorRepo.Get(indicatorId);
                area.Indicators.Remove(indicator);
                areaRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message);
            }
        }


        private void CheckIfAreaOK(Area area)
        {
            if (!area.IsValidArea())
            {
                throw new BusinessLogicException("Invalid Area");
            }
        }

        private void CheckEmtpyArea( Area area)
        {
            if (area == null)
            {
                throw new BusinessLogicException("Null area instance");
            }
        }
    }
}
