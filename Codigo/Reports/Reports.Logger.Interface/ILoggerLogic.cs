using System;
using Reports.Logger.Domain;
using System.Collections.Generic;
using Reports.Domain;
using System.Data;

namespace Reports.Logger.Interface
{
    public interface ILoggerLogic
    {
        Log Create(Log log);
        IEnumerable<Log> GetAll();
        DataSet RankingTopTen();
    }
}