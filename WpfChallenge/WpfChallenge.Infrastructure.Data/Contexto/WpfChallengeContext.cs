using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using WpfChallenge.Domain.Entities;
using WpfChallenge.Infrastructure.Data.EntityConfig;

namespace WpfChallenge.Infrastructure.Data.Contexto
{
	public class WpfChallengeContext : DbContext
	{
		public WpfChallengeContext()
			: base("WpfChallengeContact")
		{
		}

		public DbSet<Contact> Contacts { get; set; }

		#region OnModelCreating

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

		#endregion OnModelCreating

		#region SaveChanges

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

		#endregion SaveChanges
	}
}