using System;
using Reports.Domain;
using Reports.DataAccess.Interface;
using Reports.BusinessLogic.Interface;
using System.Collections.Generic;
using System.Linq;
    
namespace Reports.BusinessLogic
{
   

    public class IndicatorLogic : IIndicatorLogic
    {
        private IRepository<Indicator> repository;
        private IAreaLogic areaLogic;
        private IUserLogic userLogic;

        public IndicatorLogic(IRepository<Indicator> indicatorRepository,
            IAreaLogic areaLogic, IUserLogic userLogic) {
            repository = indicatorRepository;
            this.areaLogic = areaLogic;
            this.userLogic = userLogic;
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
        public bool CheckConditionEval(BaseCondition condition, String connectionStr)
        {
            try
            {
                bool conditionEval = condition.Eval(connectionStr);
                return true;
            }catch(DomainException e)
            {
                return false;
            }
        }
        public string GetConditionResult(BaseCondition condition, String connectionStr)
        {
            try
            {
                return condition.GetResult(connectionStr);
            }
            catch (DomainException e)
            {
                return "";
            }
        }
        public IEnumerable<IndicatorConfig> GetCustomIndicators(Guid managerId, Guid areaId)
        {
            if (areaLogic.IsManager(areaId, managerId))
            {
                return GetCustomIndicatorsByManagerAndArea(managerId, areaId);
            }
            else
            {
                return new List<IndicatorConfig>();
            }
        }
        public int CountVisibleIndicators(Guid managerId, Guid areaId)
        {
            var visibleIndicators = GetCustomIndicators(managerId, areaId)
                .Where(ci => ci.Visible == true);
            return visibleIndicators.Count();
        }
        public int CountRedIndicators(Guid managerId, Guid areaId)
        {
            try
            {
                return CountRedIndicatorsByManagerAndArea(managerId, areaId);
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Can not get result in indicator", e);
            }
        }
        public int CountYellowIndicators(Guid managerId, Guid areaId)
        {
            try
            {
                return CountYellowIndicatorsByManagerAndArea(managerId, areaId);
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Can not get result in indicator", e);
            }
        }
        public int CountGreenIndicators(Guid managerId, Guid areaId)
        {
            try
            {
                return CountGreenIndicatorsByManagerAndArea(managerId, areaId);
            }
            catch (DomainException e)
            {
                throw new BusinessLogicException("Can not get result in indicator", e);
            }
        }

        private IEnumerable<IndicatorConfig> GetCustomIndicatorsByManagerAndArea(Guid managerId, Guid areaId)
        {
            List<IndicatorConfig> iConfigs = userLogic.GetIndicatorConfigs(managerId, areaId).ToList();
            List<Indicator> areaIndicators = areaLogic.Get(areaId).Indicators.ToList();
            foreach (Indicator indicator in areaIndicators)
            {
                if (!iConfigs.Exists(ic => ic.Indicator.Id == indicator.Id))
                {
                    iConfigs.Add(new IndicatorConfig()
                    {
                        Indicator = indicator,
                        IndicatorId = indicator.Id,
                        CustomName = indicator.Name,
                    });
                }
            }
            return iConfigs;
        }
        private int CountRedIndicatorsByManagerAndArea(Guid managerId, Guid areaId)
        {
            var redIndicators = GetCustomIndicators(managerId, areaId)
                .Where(ci => ci.Visible == true && ci.Indicator.IsRedOn());
            return redIndicators.Count();
        }
        private int CountYellowIndicatorsByManagerAndArea(Guid managerId, Guid areaId)
        {
            var indicators = GetCustomIndicators(managerId, areaId)
                .Where(ci => ci.Visible == true && ci.Indicator.IsYellowOn());
            return indicators.Count();
        }
        private int CountGreenIndicatorsByManagerAndArea(Guid managerId, Guid areaId)
        {
            var indicators = GetCustomIndicators(managerId, areaId)
                .Where(ci => ci.Visible == true && ci.Indicator.IsGreenOn());
            return indicators.Count();
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
