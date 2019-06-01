using System;
using System.Collections.Generic;
using Reports.Logger.Interface;
using Reports.Logger.Domain;
using Reports.Domain;
using Reports.DataAccess.Logger.Interface;
using Reports.DataAccess.Interface;
using Reports.BusinessLogic;
using Reports.DBConnections;
using System.Data;



namespace Reports.Logger
{
    public class LoggerLogic : ILoggerLogic
    {
        private ILogRepository repository;
        public LoggerLogic(ILogRepository logRepository) {
            repository = logRepository;
        }
        public Log Create(Log log) {
            try{
                    repository.Add(log);
                    repository.Save();
                return log;
            }
            catch (Exception e)
            {
                throw new LoggerException(e.Message, e);
            }
        }
       
        public IEnumerable<Log> GetAll(){
            try {
                return repository.GetAll();
            }
            catch (Exception e)
            {
                throw new LoggerException(e.Message, e);
            }
        }

        public DataSet RankingTopTen(){
            try
            {
                IDBConnectionExcecuter conexion = new DBConnectionExcecuter();
                conexion.SetConnectionString("Server=.\\SQLEXPRESS;Database=ReportsDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
                conexion.SetQuerySQL("select top(10) UserName from [ReportsDB].[dbo].[Logs] group by UserName order by UserName desc");
                return conexion.GetResult();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
    }
}
