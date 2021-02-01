using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Core.Interfaces.Repositories;
using WpfChallenge.Domain.Entities;

namespace WpfChallenge.Infrastructure.Data.Repositorys
{
	public class RepositoryContact : RepositoryBase<Contact>, IRepositoryContact
	{
		private readonly SqlContext sqlContext;

		public RepositoryContact(SqlContext sqlContext)
			: base(sqlContext)
		{
			this.sqlContext = sqlContext;
		}
	}
}
