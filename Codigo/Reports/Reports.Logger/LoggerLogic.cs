using System;
using System.Collections.Generic;
using Reports.Logger.Interface;
using Reports.Logger.Domain;
using Reports.Domain;
using Reports.DataAccess.Logger.Interface;
using Reports.DataAccess.Interface;
using System.Linq;


namespace Reports.Logger
{
    public class LoggerLogic : ILoggerLogic
    {
        private ILogRepository LogsRepo;
        private IRepository<IndicatorConfig> IndicatorConfigRepo;


        public LoggerLogic(ILogRepository logRepository,
            IRepository<IndicatorConfig> IndicatorConfigRepo) {
            this.LogsRepo = logRepository;
            this.IndicatorConfigRepo = IndicatorConfigRepo;
        }
        public Log Create(Log log) {
            try{
                LogsRepo.Add(log);
                LogsRepo.Save();
                return log;
            }
            catch (Exception e)
            {
                throw new LoggerException(e.Message, e);
            }
        }
        public IEnumerable<Log> GetAll(){
            try {
                return LogsRepo.GetAll();
            }
            catch (Exception e)
            {
                throw new LoggerException(e.Message, e);
            }
        }
        public IEnumerable<string> ManagersMoreLogged() { 
            try
            {
                var results = (from l in LogsRepo.GetAll()
                              where l.Role == 'M'
                              group l by l.UserName into groups
                              orderby groups.Count() descending
                              select groups.Key).Take(10);
                return results.ToList();
            }
            catch (LogRepositoryInterfaceException e)
            {
                throw new LoggerException(e.Message, e);
            }
        }
        public IEnumerable<Indicator> IndicatorsMoreHidden()
        {
            try { 
                var results = (from ic in IndicatorConfigRepo.GetAll()
                               where ic.User.Admin == false && ic.Visible == false
                               group ic.Indicator by ic.Indicator into groups
                               orderby groups.Count() descending
                               select groups.Key).Take(10);
                return results.ToList();
            }catch(RepositoryInterfaceException e)
            {
                throw new LoggerException(e.Message, e);
            }
        }

        public IEnumerable<Log> ActionLogsByDate(DateTime start, DateTime end)
        {
            try
            {
                ThrowExceptionIfDatesNotOk(start, end);
                var results = from logs in LogsRepo.GetAll()
                              where logs.Date >= start && logs.Date <= end
                              select logs;
                return results.ToList();
            }
            catch (LogRepositoryInterfaceException e)
            {
                throw new LoggerException(e.Message, e);
            }
        }

        private void ThrowExceptionIfDatesNotOk(DateTime start, DateTime end)
        {
            if (start == null || end == null ||
                start > end)
                throw new LoggerException("Dates are not ok");
        }
    }
}
