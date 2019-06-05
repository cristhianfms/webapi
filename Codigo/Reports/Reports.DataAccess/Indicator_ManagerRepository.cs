using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Reports.DataAccess
{
    public class IndicatorDisplayRepository : BaseRepository<Indicator_Manager>
    {
        public IndicatorDisplayRepository(DbContext context)
        {
            Context = context;
        }
        public override IEnumerable<Indicator_Manager> GetAll(){
            return Context.Set<Indicator_Manager>().ToList();
        }

        public override Indicator_Manager Get(Guid id){
            //IndicatorDisplay indicatorDisplay = Context.Set<IndicatorDisplay>().ToList().FirstOrDefault(a => a.Id == id);
            //if(indicatorDisplay == null){
            //    throw new RepositoryException("Id not found");
            //}
            //return indicatorDisplay;
            throw new Exception("test");
        }



    }
}