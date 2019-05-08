using Reports.Logger.Domain;
using Microsoft.EntityFrameworkCore;


namespace Reports.DataAccess.Logger
{
    public class LogReportsContext : DbContext
    {
        public DbSet<Log> Log { get; set; }
         public LogReportsContext(DbContextOptions options) : base(options)
        {
        }
    }
}

