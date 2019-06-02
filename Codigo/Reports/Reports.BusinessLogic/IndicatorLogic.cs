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
        public string GetResult(Indicator indicator, Color color, string areaConnectionStr)
        {
            if (color == Color.Green)
            {
                return GetGreenResult(indicator, areaConnectionStr);
            }
            else if (color == Color.Yellow)
            {
                return GetYellowResult(indicator, areaConnectionStr);
            }
            else if (color == Color.Red)
            {
                return GetRedResult(indicator, areaConnectionStr);
            }
            return "";
        }
        public Color GetOnCondition(Indicator indicator, string areaConnectionStr)
        {
            if (indicator.IsGreenOn(areaConnectionStr))
            {
                return Color.Green;
            }
            else if (indicator.IsYellowOn(areaConnectionStr))
            {
                return Color.Yellow;
            }
            else if (indicator.IsRedOn(areaConnectionStr))
            {
                return Color.Red;
            }
            return Color.Green;
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
        private string GetGreenResult(Indicator indicator, string areaConnectionStr)
        {
            try
            {
                return indicator.GetGreenResult(areaConnectionStr);
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Error in condition", e);
            }
        }
        private string GetYellowResult(Indicator indicator, string areaConnectionStr)
        {
            try
            {
                return indicator.GetYellowResult(areaConnectionStr);
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Error in condition", e);
            }
        }
        private string GetRedResult(Indicator indicator, string areaConnectionStr)
        {
            try
            {
                return indicator.GetRedResult(areaConnectionStr);
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Error in condition", e);
            }
        }

    }
}
