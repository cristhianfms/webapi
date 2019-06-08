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
                    .ToList().FirstOrDefault(ic => ic.Id == id);

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
        public IndicatorConfig Get(Guid indicatorId, Guid userId)
        {
            try
            {
                IndicatorConfig indicatorconf = Context.Set<IndicatorConfig>()
                    .FirstOrDefault(ic => ic.IndicatorId == indicatorId && ic.UserId == userId);
                if (indicatorconf == null)
                {
                    throw new RepositoryException("Id not found");
                }
                return indicatorconf;
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }
    }
}