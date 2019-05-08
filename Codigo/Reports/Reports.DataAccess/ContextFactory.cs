using Microsoft.EntityFrameworkCore;

namespace Reports.DataAccess
{
    public static class ContextFactory{

        public static ReportsContext GetMemoryContext(string nameBd) {
            var builder = new DbContextOptionsBuilder<ReportsContext>();
            return new ReportsContext(GetMemoryConfig(builder, nameBd));
        }

        public static ReportsContext GetSqlContext()
        { 
            var builder = new DbContextOptionsBuilder<ReportsContext>();
            return new ReportsContext(GetSqlConfig(builder));
        }


        private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder, string nameBd) {
            builder.UseInMemoryDatabase(nameBd);
            return builder.Options;
        }

        private static DbContextOptions GetSqlConfig(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HomeworksDB;
                Trusted_Connection=True;MultipleActiveResultSets=True;");
            return builder.Options;
        }
    }
}