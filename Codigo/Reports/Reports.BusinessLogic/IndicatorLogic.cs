using System;
using Reports.Domain;
using Reports.DataAccess.Interface;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
    
namespace Reports.BusinessLogic
{
   

    public class IndicatorLogic : IIndicatorLogic
    {
        private IRepository<Indicator> repository;
        public IndicatorLogic(IRepository<Indicator> indicatorRepository) {
            repository = indicatorRepository;
        }
        public Indicator Create(Indicator indicator) {
            try
            {
                CheckEmtpyIndicator(indicator);
                indicator.Id = Guid.NewGuid();
                CheckValidIndicator(indicator);
                repository.Add(indicator);
                repository.Save();
                return indicator;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public void Remove(Guid id) {
            try
            {
                Indicator indicatorToDelete = repository.Get(id);
                repository.Remove(indicatorToDelete);
                repository.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }   
        public Indicator Update(Indicator indicator) {
            try
            {
                CheckEmtpyIndicator(indicator);
                CheckValidIndicator(indicator);
                Indicator indicatorToUpdate = repository.Get(indicator.Id);
                indicatorToUpdate.Name = indicator.Name;
                indicatorToUpdate.GreenCondition = indicator.GreenCondition;
                indicatorToUpdate.YellowCondition = indicator.YellowCondition;
                indicatorToUpdate.RedCondition = indicator.RedCondition;
                repository.Update(indicatorToUpdate);
                repository.Save();
                return indicatorToUpdate;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public Indicator Get(Guid id){
            try {
                return repository.Get(id);
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public IEnumerable<Indicator> GetAll(){
            try {

                return repository.GetAll();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        private void CheckEmtpyIndicator(Indicator indicator)
        {
            if (indicator == null) throw new BusinessLogicException("Null indicator");
        }
        private void CheckValidIndicator(Indicator indicator)
        {
            if (!indicator.IsValid())
                throw new BusinessLogicException("Not valid indicator");
        }
    }
}
