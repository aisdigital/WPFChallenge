using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Entities;
using WpfChallenge.Infrastructure.Data.EntityConfig;

namespace WpfChallenge.Infrastructure.Data
{
	public class SqlContext : DbContext
	{
		public SqlContext()
			: base("WpfChallengeContact")
		{
				
		}

		public DbSet<Contact> Contacts { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties()
				.Where(p => p.Name == p.ReflectedType.Name + "Id")
				.Configure(p => p.IsKey());

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

			modelBuilder.Properties<string>()
				.Configure(p => p.HasMaxLength(100));

			modelBuilder.Configurations.Add(new ContactConfiguration());
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("RegisterDate").CurrentValue = DateTime.Now;
				}
				if (entry.State == EntityState.Modified)
				{
					entry.Property("RegisterDate").IsModified = false;
				}
			}
			return base.SaveChanges();
		}
	}
}
