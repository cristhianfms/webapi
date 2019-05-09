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
            try{
                if (indicator.IsValidIndicator(indicator)) {
                    repository.Add(indicator);
                    repository.Save();
                    return indicator;
                }
                else { 
                   throw new BusinessLogicException("null Indicator");
                }
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public void Remove(Indicator indicator) {
            try {
                 if (indicator.IsValidIndicator(indicator)) {
                    repository.Remove(indicator);
                    repository.Save();
                }
                else { 
                   throw new BusinessLogicException("null Indicator");
                }
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }   
        public void Update(Indicator indicator) {
            try {
                 if (indicator.IsValidIndicator(indicator)) {
                    repository.Update(indicator);
                    repository.Save();
                }
                else { 
                   throw new BusinessLogicException("null Indicator");
                }
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


    }
}
