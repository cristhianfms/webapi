using System;
using System.Collections.Generic;
using Reports.Logger.Domain;

namespace Reports.DataAccess.Logger.Interface
{
    public interface ILogRepository
    {
        void Add(Log entity);
        IEnumerable<Log> GetAll();
        void Save();
    }
}