using System;
using System.Collections.Generic;
using Reports.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace Reports.DataAccess
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext Context {get; set;}

        public void Add(T entity) 
        {
            try
            {
                Context.Set<T>().Add(entity);
            }
            catch (Exception e){
                throw new RepositoryException(e.Message, e);
            }
        }

        public void Remove(T entity) 

        {
            try
            {
                Context.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message, e);
            }
        }

        public void Update(T entity) 
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception e)
            {

                throw new RepositoryException(e.Message, e);
            }
        }

        public void Save() 
        {
            try
            {
                Context.SaveChanges();    
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message, e);
            }
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T Get(Guid id);

    }
}
