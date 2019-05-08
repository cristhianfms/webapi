using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Reports.Logger.Interface;
using Reports.Logger.Domain;
using Reports.Domain;
using Reports.DataAccess.Logger.Interface;
using System.Linq;
using Reports.DataAccess.Logger;
using Moq;

namespace Reports.Logger.Test
{
    [TestClass]
    public class LoggerLogicTest
    {
        [TestMethod]
        public void CreateLogOk()
        {
            Guid id = Guid.NewGuid();
            Log log = new Log{
                Id = id,
                Date = DateTime.Now
            };
            var context = LogContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            ILogRepository logRepo = new LogRepository(context);
            LoggerLogic loggerLogic = new LoggerLogic(logRepo);
            loggerLogic.Create(log);
            var logs =  logRepo.GetAll().ToList();
            Assert.AreEqual(logs[0].Id, id);
        }
        [TestMethod]
        public void CreateLogWithMockOk()
        {
            Guid id = Guid.NewGuid();
            Log log = new Log{
                Id = id,
                Date = DateTime.Now
            };
            var mock = new Mock<ILogRepository>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Log>()));
            mock.Setup(m => m.Save());
            LoggerLogic loggerLogic = new LoggerLogic(mock.Object);

            loggerLogic.Create(log);

            mock.VerifyAll();
        }
        [TestMethod]
        public void GetAllLogOk()
        {
            Guid id = Guid.NewGuid();
            Log log = new Log{
                Id = id,
                Date = DateTime.Now
            };
            var context = LogContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            ILogRepository logRepo = new LogRepository(context);
            LoggerLogic loggerLogic = new LoggerLogic(logRepo);
            loggerLogic.Create(log);
            var logs = loggerLogic.GetAll().ToList();
            Assert.AreEqual(logs[0].Id, id);
        }
    }
}
