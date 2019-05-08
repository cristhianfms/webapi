using System;
using Reports.Logger.Domain;
using System.Collections.Generic;
using Reports.Domain;

namespace Reports.Logger.Interface
{
    public interface ILoggerLogic
    {
        void Create(Log log);
        IEnumerable<Log> GetAll();
        IEnumerable<User> RankingTopTen();
    }
}