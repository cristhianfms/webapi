using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Reports.DataAccess
{
    public class AreaUserRepository : BaseRepository<AreaUser>
    {
        public AreaUserRepository(DbContext context)
        {
            Context = context;
        }

        public override AreaUser Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AreaUser> GetAll(){
            try
            {
                return Context.Set<AreaUser>()
                    .ToList();
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }

        }
    }
}