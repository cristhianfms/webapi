using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Reports.DataAccess
{
    public class AreaManagerRepository : BaseRepository<AreaManager>
    {
        public AreaManagerRepository(DbContext context)
        {
            Context = context;
        }

        public override AreaManager Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AreaManager> GetAll(){
            return Context.Set<AreaManager>()
                .Include(am=>am.Area)
                .Include(am=>am.Manager)
                .ToList();
        }
    }
}