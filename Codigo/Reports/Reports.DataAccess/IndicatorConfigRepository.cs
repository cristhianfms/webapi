using System;
using Reports.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Reports.DataAccess.Interface;

namespace Reports.DataAccess
{
    public class IndicatorConfigRepository : BaseRepository<IndicatorConfig>
    {
        public IndicatorConfigRepository(DbContext context)
        {
            Context = context;
        }

        public override IndicatorConfig Get(Guid id)
        {
            try
            {
                IndicatorConfig imc = Context.Set<IndicatorConfig>()
                    .ToList().FirstOrDefault(im => im.Id == id);

                if (imc == null)
                {
                    throw new RepositoryException("Id not found");
                }
                return imc;
            }
            catch (Exception e)
            {

                throw new RepositoryException(e.Message);
            }
        }

        public override IEnumerable<IndicatorConfig> GetAll()
        {
            try
            {
                return Context.Set<IndicatorConfig>()
                    .ToList();
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }

        public IndicatorConfig Get(Guid indicatorId, Guid managerId)
        {
            try
            {
                IndicatorConfig imc = Context.Set<IndicatorConfig>()
                    .FirstOrDefault(im => im.IndicatorId == indicatorId && im.ManagerId == managerId);
                if (imc == null)
                {
                    throw new RepositoryException("Id not found");
                }
                return imc;
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }
    }
}