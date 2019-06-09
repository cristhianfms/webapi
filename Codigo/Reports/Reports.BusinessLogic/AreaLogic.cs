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
        private IRepository<AreaUser> areaUserRepo;
        private IRepository<User> userRepo;
        private IRepository<Indicator> indicatorRepo;

        public AreaLogic(IRepository<Area> areaRepo , IRepository<AreaUser> areaManagerRepo
            , IRepository<User> userRepo, IRepository<Indicator> indicatorRepo) {

            this.areaRepo = areaRepo;
            this.areaUserRepo = areaManagerRepo;
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
                return areaUserRepo.GetAll().Where(am => am.AreaId == areaId)
                .Select(c => c.User);
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public void AddManager(Guid areaId, Guid userId)
        {
            try { 
                User manager = userRepo.Get(userId);
                Area area = areaRepo.Get(areaId);
                AreaUser areaManager = new AreaUser()
                {
                    AreaId = areaId,
                    Area = area,
                    UserId = userId,
                    User = manager
                };
                areaUserRepo.Add(areaManager);
                areaUserRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                    throw new BusinessLogicException(e.Message, e);
            }
        }
        public void RemoveManager(Guid areaId, Guid userId)
        {
            try
            {
                AreaUser areaManager = new AreaUser()
                {
                    AreaId = areaId,
                    UserId = userId
                };
                areaUserRepo.Remove(areaManager);
                areaUserRepo.Save();
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
                area.Indicators.ToList().Add(indicator);
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
                area.Indicators.ToList().Remove(indicator);
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
