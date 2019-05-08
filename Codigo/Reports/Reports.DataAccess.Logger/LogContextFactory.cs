using Microsoft.EntityFrameworkCore;

namespace Reports.DataAccess.Logger
{
    public static class LogContextFactory{
        public static LogReportsContext GetMemoryContext(string nameBd) {
            var builder = new DbContextOptionsBuilder<LogReportsContext>();
            return new LogReportsContext(GetMemoryConfig(builder, nameBd));
        }

        private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder, string nameBd) {
            builder.UseInMemoryDatabase(nameBd);
            return builder.Options;
        }     
    }
}