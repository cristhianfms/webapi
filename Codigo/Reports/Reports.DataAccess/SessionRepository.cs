using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Reports.DataAccess
{
    public class SessionRepository : BaseRepository<Session>
    {
        public SessionRepository(DbContext context)
        {
            Context = context;
        }
        public override IEnumerable<Session> GetAll(){
            return Context.Set<Session>().ToList();
        }

        public override Session Get(Guid id){
            Session session = Context.Set<Session>().ToList().FirstOrDefault(u => u.Id == id);
            if (session==null) {
                throw new RepositoryException("Id not found");
            }
            return session;
        }
    }
}