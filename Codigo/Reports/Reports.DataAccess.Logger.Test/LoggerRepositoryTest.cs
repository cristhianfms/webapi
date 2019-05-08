using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Reports.DataAccess.Logger;
using Reports.DataAccess.Logger.Interface;
using Reports.Logger.Domain;

namespace Reports.DataAccess.Logger.Test
{
    [TestClass]
    public class LoggerRepositoryTest
    {
        [TestMethod]
        public void AddLogOK(){
            var context = LogContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            ILogRepository logRepo = new LogRepository(context);
            Guid id = Guid.NewGuid();
            Log log = new Log{
                Id = id,
                Date = DateTime.Now
            };
            logRepo.Add(log);
            logRepo.Save();
            var logs =  logRepo.GetAll().ToList();
            Assert.AreEqual(logs[0].Id, id);
        }
        [TestMethod]
        public void AddtwoLogToSameUserOK(){
            var context = LogContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            ILogRepository logRepo = new LogRepository(context);
            Guid id = Guid.NewGuid();
            Log log = new Log{
                Id = Guid.NewGuid(),
                UserId = id,
                Date = DateTime.Now
            };
            Log log2 = new Log {
                Id = Guid.NewGuid(),
                UserId = id,
                Date = DateTime.Now
            };
            logRepo.Add(log);
            logRepo.Save();
            logRepo.Add(log2);
            logRepo.Save();
            var logs =  logRepo.GetAll().ToList();
            Assert.AreEqual(logs.Count, 2);
        }
                [TestMethod]
        public void GetAllLogOK(){
            var context = LogContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            ILogRepository logRepo = new LogRepository(context);
            Guid id = Guid.NewGuid();
            Log log = new Log{
                Id = Guid.NewGuid(),
                UserId = id,
                Date = DateTime.Now
            };
            Log log2 = new Log {
                Id = Guid.NewGuid(),
                UserId = id,
                Date = DateTime.Now
            };
            logRepo.Add(log);
            logRepo.Save();
            logRepo.Add(log2);
            logRepo.Save();
            var logs =  logRepo.GetAll().ToList();
             Assert.IsTrue(logs[0].UserId == id && logs[1].UserId == id);
            
        }
        [TestMethod]
        public void GetWhitOutId()
        {   
            var context = LogContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            ILogRepository logRepo = new LogRepository(context);
            var logs =  logRepo.GetAll().ToList();
            Assert.AreEqual(logs.Count, 0);
        }
    }
}
