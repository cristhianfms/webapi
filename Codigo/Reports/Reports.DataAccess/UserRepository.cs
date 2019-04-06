using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Reports.DataAccess
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DbContext context)
        {
            Context = context;
        }
        public override IEnumerable<User> GetAll(){
            return new List<User>();
        }

        public override User Get(Guid id){
            return new User();
        }
    }
}