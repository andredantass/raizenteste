using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RaizenUserRegister.Domain.Aggregates;

namespace RaizenUserRegister.Infra.Data.DBContext
{
    public class RaizenDBContext : DbContext
    {
        public static string Schema => "raizen";

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public RaizenDBContext(DbContextOptions<RaizenDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValue("NEWID()");
            modelBuilder.Entity<Address>().Property(x => x.Id).HasDefaultValue("NEWID()");

            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);
        }

        public class IntegrationContextFactory : IDesignTimeDbContextFactory<RaizenDBContext>
        {
            public RaizenDBContext CreateDbContext(string[] args)
            {
                var optionBuilder = new DbContextOptionsBuilder<RaizenDBContext>();

                optionBuilder.UseSqlServer("Data Source=localhost;Database=RaizenDB;Trusted_Connection=True;Trust Server Certificate = true;");

                return new RaizenDBContext(optionBuilder.Options);
            }
        }
    }
}
