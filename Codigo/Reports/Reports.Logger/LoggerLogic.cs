using System;
using System.Collections.Generic;
using Reports.Logger.Interface;
using Reports.Logger.Domain;
using Reports.Domain;
using Reports.DataAccess.Logger.Interface;

    

namespace Reports.Logger
{
    public class LoggerLogic : ILoggerLogic
    {
        private ILogRepository repository;
        public LoggerLogic(ILogRepository logRepository) {
            repository = logRepository;
        }
        public void Create(Log log) {
            try{
                    repository.Add(log);
                    repository.Save();
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

        public IEnumerable<User> RankingTopTen(){
            return null;
             try
            {
    //conexion a la base, hacer un 
    //select top(10) from la_tabla where group by user_id, ordey by user_id desc
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
    }
}
