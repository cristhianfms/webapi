using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Reports.DataAccess
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DbContext context)
        {
            Context = context;
        }

        public override IEnumerable<User> GetAll(){
            try
            {
                return Context.Set<User>().ToList();
            }
            catch (Exception e)
            {

                throw new RepositoryException(e.Message);
            }
        }

        public override User Get(Guid id){
            try
            {
                User user = Context.Set<User>().ToList().FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    throw new RepositoryException("Id not found");
                }
                return user;
            }
            catch (Exception e)
            {

                throw new RepositoryException(e.Message);
            }
        }
    }
}