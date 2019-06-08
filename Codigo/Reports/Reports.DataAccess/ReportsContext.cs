using Reports.Domain;
using Microsoft.EntityFrameworkCore;


namespace Reports.DataAccess
{
    public class ReportsContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Indicator> Indicators { get; set; }

        public DbSet<Condition> Conditions { get; set; }
        public DbSet<AndCondition> AndConditions { get; set; }
        public DbSet<OrCondition> OrConditions { get; set; }
        
        public DbSet<SQLValue> SQLValues { get; set; }
        public DbSet<StringValue> StringValues { get; set; }
        public DbSet<IntValue> IntValues { get; set; }

        public DbSet<IndicatorConfig> IndicatorConfigs { get; set; }
        public DbSet<AreaUser> AreaUsers { get; set; }

        public ReportsContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasAlternateKey(u => u.UserName);
            modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();

            modelBuilder.Entity<Area>().HasAlternateKey(a => a.Name);
            modelBuilder.Entity<Area>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Area>().Property(a => a.ConnectionString).IsRequired();

            modelBuilder.Entity<BaseCondition>().ToTable("Conditions");
            modelBuilder.Entity<Value>().ToTable("Values");
            modelBuilder.Entity<CompositeCondition>().HasBaseType<BaseCondition>();

            modelBuilder.Entity<AreaUser>().HasKey(x => new { x.AreaId, x.UserId });
            modelBuilder.Entity<IndicatorConfig>().HasKey(x => new { x.IndicatorId, x.UserId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

