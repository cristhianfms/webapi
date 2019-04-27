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
                   throw new Exception("Invalid area");
                }
            }
            catch (Exception e){
                throw new Exception(e.Message);
            }
        }
        public void RemoveArea(Area area) {
            try {
                 if (area.isValidArea(area)) {
                    repository.Remove(area);
                    repository.Save();
                }
                else { 
                   throw new Exception("Invalid area");
                }
            }
            catch(Exception e) {
                throw new Exception(e.Message);
            }
        }   
        public void UpdateArea(Area area) {
            try {
                 if (area.isValidArea(area)) {
                    repository.Update(area);
                    repository.Save();
                }
                else { 
                   throw new Exception("Invalid area");
                }
            }
            catch(Exception e) {
                throw new Exception(e.Message);
            }
        }
         Area Get(Guid id){
             try {
                return repository.Get(id);
             }
             catch(Exception e) {
                throw new Exception(e.Message);
            }
        }
        IEnumerable<Area> GetAll(){
            try {
                return repository.GetAll();
            }
            catch(Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}
