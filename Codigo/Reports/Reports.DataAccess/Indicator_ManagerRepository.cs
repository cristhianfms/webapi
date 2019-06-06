using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Reports.DataAccess.Interface;

namespace Reports.DataAccess
{
    public class Indicator_ManagerRepository : BaseRepository<Indicator_Manager>
    {
        public Indicator_ManagerRepository(DbContext context)
        {
            Context = context;
        }

        public override Indicator_Manager Get(Guid id)
        {
            try
            {
                Indicator_Manager indicator_manager = Context.Set<Indicator_Manager>()
                    .ToList().FirstOrDefault(im => im.Id == id);

                if (indicator_manager == null)
                {
                    throw new RepositoryException("Id not found");
                }
                return indicator_manager;
            }
            catch (Exception e)
            {

                throw new RepositoryException(e.Message);
            }
        }

        public override IEnumerable<Indicator_Manager> GetAll()
        {
            try
            {
                return Context.Set<Indicator_Manager>()
                    .ToList();
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }

        public Indicator_Manager Get(Guid indicatorId, Guid managerId)
        {
            try
            {
                Indicator_Manager indicator_manager = Context.Set<Indicator_Manager>()
                    .FirstOrDefault(im => im.IndicatorId == indicatorId && im.ManagerId == managerId);
                if (indicator_manager == null)
                {
                    throw new RepositoryException("Id not found");
                }
                return indicator_manager;
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }
    }
}