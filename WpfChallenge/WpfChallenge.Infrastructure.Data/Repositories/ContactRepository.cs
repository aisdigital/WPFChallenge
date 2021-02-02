using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Entities;
using WpfChallenge.Domain.Interfaces.Repositories;

namespace WpfChallenge.Infrastructure.Data.Repositories
{
	public class ContactRepository : RepositoryBase<Contact>, IContactRepository
	{
	}
}
