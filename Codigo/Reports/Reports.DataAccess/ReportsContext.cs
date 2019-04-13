using Reports.Domain;
using Microsoft.EntityFrameworkCore;

namespace Reports.DataAccess
{
    public class ReportsContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Area> Area {get; set;}
        public DbSet<Indicator> Indicators {get; set;}
        public DbSet<Color> Colors {get; set;}

        public ReportsContext(DbContextOptions options) : base(options)
        {

                                   
        }

    }
}

