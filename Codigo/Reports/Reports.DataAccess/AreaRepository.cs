using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Reports.DataAccess
{
    public class AreaRepository : BaseRepository<Area>
    {
        public AreaRepository(DbContext context)
        {
            Context = context;
        }
        public override IEnumerable<Area> GetAll(){
            return Context.Set<Area>().ToList();
        }

        public override Area Get(Guid id){
            Area area = Context.Set<Area>().ToList().FirstOrDefault(a => a.Id == id);
            if(area == null){
                throw new RepositoryException("Id not found");
            }
            return area;
        }
    }
}