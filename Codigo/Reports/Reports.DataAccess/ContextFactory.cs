using Microsoft.EntityFrameworkCore;

namespace Reports.DataAccess
{
    public static class ContextFactory{
        public static ReportsContext GetMemoryContext(string nameBd) {
            var builder = new DbContextOptionsBuilder<ReportsContext>();
            return new ReportsContext(GetMemoryConfig(builder, nameBd));
        }

        private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder, string nameBd) {
            builder.UseInMemoryDatabase(nameBd);
            return builder.Options;
        }     
    }
}