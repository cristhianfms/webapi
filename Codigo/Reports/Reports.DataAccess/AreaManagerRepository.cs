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
            try
            {
                return Context.Set<AreaManager>()
                    .Include(am => am.Area)
                    .Include(am => am.Manager)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }

        }
    }
}