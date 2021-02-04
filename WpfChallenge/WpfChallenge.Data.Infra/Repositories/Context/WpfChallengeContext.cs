using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using WpfChallenge.Data.Infra.Repositories.Map;
using WpfChallenge.Domain.Entities;

namespace MySchool.Infra.Data.Repositories.Context
{
    public class WpfChallengeContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AspCore_NovoDB;Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ignorar classes
            modelBuilder.Ignore<Notification>();

            //aplicar configurações
            modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
