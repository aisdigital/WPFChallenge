using WpfChallenge.Domain.Entities;
using WpfChallenge.Domain.Interfaces.Repositories;

namespace WpfChallenge.Infrastructure.Data.Repositories
{
	public class ContactRepository : RepositoryBase<Contact>, IContactRepository
	{
	}
}