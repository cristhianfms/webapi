using System;
using System.Collections.Generic;
using Reports.DataAccess.Logger.Interface;
using Microsoft.EntityFrameworkCore;
using Reports.Logger.Domain;
using Reports.Logger;
using System.Linq;

namespace Reports.DataAccess.Logger
{
    public class LogRepository : ILogRepository
    {
        protected DbContext Context {get; set;}

        public LogRepository(DbContext context)
        {
            Context = context;
        }
        public void Add(Log entity) 
        {
            try
            {
                Context.Set<Log>().Add(entity);
            }
            catch (Exception e){
                throw new LoggerException(e.Message, e);
            }
        }
        public IEnumerable<Log> GetAll(){
             return Context.Set<Log>().ToList();
        }
        public void Save() 
        {
            try
            {
                Context.SaveChanges();    
            }
            catch (Exception e)
            {
                throw new LoggerException(e.Message, e);
            }
        }
    }
}
