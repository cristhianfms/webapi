using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Reports.DataAccess
{
    public class IndicatorDisplayRepository : BaseRepository<IndicatorDisplay>
    {
        public IndicatorDisplayRepository(DbContext context)
        {
            Context = context;
        }
        public override IEnumerable<IndicatorDisplay> GetAll(){
            return Context.Set<IndicatorDisplay>().ToList();
        }

        public override IndicatorDisplay Get(Guid id){
            IndicatorDisplay indicatorDisplay = Context.Set<IndicatorDisplay>().ToList().FirstOrDefault(a => a.Id == id);
            if(indicatorDisplay == null){
                throw new RepositoryException("Id not found");
            }
            return indicatorDisplay;
        }
    }
}