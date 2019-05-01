using System;
using Reports.Domain;
using Reports.DataAccess.Interface;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
    
namespace Reports.BusinessLogic
{
    public class AreaLogic : IAreaLogic
    {
        private IRepository<Area> repository;
        public AreaLogic(IRepository<Area> areaRepository) {
            repository = areaRepository;
        }
        public void CreateArea(Area area) {
            try{
                if (area.isValidArea(area)) {
                    repository.Add(area);
                    repository.Save();
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
                 if (area.isValidArea(area)) {
                    repository.Remove(area);
                    repository.Save();
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
                 if (area.isValidArea(area)) {
                    repository.Update(area);
                    repository.Save();
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
         Area Get(Guid id){
            try {
                return repository.Get(id);
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        IEnumerable<Area> GetAll(){
            try {
                return repository.GetAll();
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

    }
}
