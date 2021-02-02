using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Entities;

namespace WpfChallenge.Infrastructure.Data.EntityConfig
{
	public class ContactConfiguration : EntityTypeConfiguration<Contact>
	{
		public ContactConfiguration()
		{
			HasKey(c => c.ContactId);

			Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(150);

			Property(c => c.Phone)
				.IsRequired()
				.HasMaxLength(20);

			Property(c => c.Email)
				.IsRequired();

			Property(c => c.Address)
				.IsRequired()
				.HasMaxLength(250);
		}
	}
}
