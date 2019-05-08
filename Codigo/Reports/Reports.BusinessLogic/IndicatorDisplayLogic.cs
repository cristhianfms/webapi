using System;
using System.Collections.Generic;
using Reports.BusinessLogic.Interface;
using Reports.Domain;
using Reports.DataAccess.Interface;

namespace Reports.BusinessLogic
{
    public class IndicatorDisplayLogic : IndicatorDisplay
    {
        private IRepository<IndicatorDisplay> indDisplayRepo;

        public IndicatorDisplayLogic(IRepository<IndicatorDisplay> indDisplayRepo)
        {
            try {
                this.indDisplayRepo = indDisplayRepo;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public void Create(IndicatorDisplay indDisplay) {
            try
            {
                indDisplay.Id = Guid.NewGuid();
                indDisplayRepo.Add(indDisplay);
                indDisplayRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public IndicatorDisplay Get(Guid id)
        {
            try
            {
                return this.indDisplayRepo.Get(id);
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }

        }

        public IEnumerable<IndicatorDisplay> GetAll()
        {
            try
            {
                return this.indDisplayRepo.GetAll();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public void Remove(IndicatorDisplay indDisplay)
        {
            try
            {
                this.indDisplayRepo.Remove(indDisplay);
                this.indDisplayRepo.Save();
            }
            catch(RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public void Update(IndicatorDisplay indDisplay)
        {
            try
            {
                this.indDisplayRepo.Update(indDisplay);
                this.indDisplayRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public IEnumerable<IndicatorDisplay> GetAllByManagerId(Guid managerId)
        {
            try
            {
                IEnumerable<IndicatorDisplay> all = this.indDisplayRepo.GetAll();
                IEnumerable<IndicatorDisplay> allByMangerId = new IEnumerable<IndicatorDisplay>();
                foreach(IndicatorDisplay ind in all){
                    if(ind.Id == managerId){
                        allByMangerId.Add(ind);
                    }
                }
                return allByMangerId;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public Guid TopTenHiddenIndicator()
        {
            try
            {
    //conexion a la base, hacer un 
    //select top(10) from la_tabla where visible = false group by indicator_id, visible ordey by user_id desc
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
    }
}
