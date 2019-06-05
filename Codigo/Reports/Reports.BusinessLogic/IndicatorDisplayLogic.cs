using System;
using System.Collections.Generic;
using Reports.BusinessLogic.Interface;
using Reports.Domain;
using Reports.DataAccess.Interface;

namespace Reports.BusinessLogic
{
    public class Indicator_ManagerLogic : IIndicator_ManagerLogic
    {
        private IRepository<Indicator_Manager> indDisplayRepo;

        public Indicator_ManagerLogic(IRepository<Indicator_Manager> indDisplayRepo)
        {
            try {
                this.indDisplayRepo = indDisplayRepo;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public void Create(Indicator_Manager indDisplay) {
            try
            {
                indDisplay.Indicator_ManagerId = Guid.NewGuid();
                indDisplayRepo.Add(indDisplay);
                indDisplayRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }

        public Indicator_Manager Get(Guid id)
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

        public IEnumerable<Indicator_Manager> GetAll()
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

        public void Remove(Indicator_Manager indDisplay)
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

        public void Update(Indicator_Manager indDisplay)
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
        public IEnumerable<Indicator_Manager> GetAllByManagerId(Guid managerId)
        {
            try
            {
                IEnumerable<Indicator_Manager> all = this.indDisplayRepo.GetAll();
               var allByMangerId = new List<Indicator_Manager>();
                foreach(Indicator_Manager ind in all){
                    if(ind.Indicator_ManagerId == managerId){
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
        public IEnumerable<Guid> TopTenHiddenIndicator()
        {
            try
            {
                return null;
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
