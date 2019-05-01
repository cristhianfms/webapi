using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Reports.DataAccess
{
    public class IndicatorRepository : BaseRepository<Indicator>
    {
        public IndicatorRepository(DbContext context)
        {
            Context = context;
        }
        public override IEnumerable<Indicator> GetAll(){
            return Context.Set<Indicator>().ToList();
        }

        public override Indicator Get(Guid id){
            Indicator indicator = Context.Set<Indicator>().ToList().FirstOrDefault(u => u.Id == id);
            if (indicator==null) {
                throw new RepositoryException("Id not found");
            }
            return indicator;
        }
    }
}