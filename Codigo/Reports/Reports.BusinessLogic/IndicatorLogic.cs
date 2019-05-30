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
        public void Remove(Indicator indicator) {
            try
            {
                CheckEmtpyIndicator(indicator);
                CheckValidIndicator(indicator);
                repository.Remove(indicator);
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
                repository.Update(indicator);
                repository.Save();
                return indicator;
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
        public string GetResult(Indicator indicator, Color color)
        {
            if (color == Color.Green)
            {
                return GetGreenResult(indicator);
            }
            else if (color == Color.Yellow)
            {
                return GetYellowResult(indicator);
            }
            else if (color == Color.Yellow)
            {
                return GetRedResult(indicator);
            }
            return "";
        }


        private string GetGreenResult(Indicator indicator)
        {
            try
            {
                return indicator.GetGreenResult();
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Error in condition", e);
            }
        }

        private string GetYellowResult(Indicator indicator)
        {
            try
            {
                return indicator.GetYellowResult();
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Error in condition", e);
            }
        }

        private string GetRedResult(Indicator indicator)
        {
            try
            {
                return indicator.GetRedResult();
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Error in condition", e);
            }
        }


    }
}
