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
        public DbSet<AndCondition> LogicAnds { get; set; }
        public DbSet<OrCondition> LogicOrs { get; set; }
        
        public DbSet<SQLValue> SQLValues { get; set; }
        public DbSet<StringValue> StringValues { get; set; }
        public DbSet<IntValue> IntValues { get; set; }

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

            modelBuilder.Entity<Indicator>().Property(i => i.Color).IsRequired();

            modelBuilder.Entity<IndicatorDisplay>().Property(i => i.UserId).IsRequired();
            modelBuilder.Entity<IndicatorDisplay>().Property(i => i.AreaId).IsRequired();
            modelBuilder.Entity<IndicatorDisplay>().Property(i => i.Orden).IsRequired();
            modelBuilder.Entity<IndicatorDisplay>().Property(i => i.Visible).IsRequired();


            modelBuilder.Entity<BaseCondition>().ToTable("Conditions");

            modelBuilder.Entity<CompositeCondition>().HasBaseType<BaseCondition>();

            modelBuilder.Entity<Value>().ToTable("Values");

            modelBuilder.Entity<AreaManager>().HasKey(x => new { x.AreaId, x.ManagerId });
            modelBuilder.Entity<IndicatorDisplay>().HasKey(x => new { x.AreaId, x.UserId,x.IndicatorId });
            
            modelBuilder.Entity<AreaManager>().HasOne<Area>(am => am.Area)
                .WithMany(a => a.AreaManagers);
            modelBuilder.Entity<AreaManager>().HasOne<User>(am => am.Manager)
                .WithMany(m => m.AreaManagers);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

