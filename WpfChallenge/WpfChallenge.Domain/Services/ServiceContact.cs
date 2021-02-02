using WpfChallenge.Domain.Entities;
using WpfChallenge.Domain.Interfaces.Repositories;
using WpfChallenge.Domain.Interfaces.Services;

namespace WpfChallenge.Domain.Services
{
	public class ServiceContact : ServiceBase<Contact>, IServiceContact
	{
		private readonly IContactRepository _contactRepository;

		public ServiceContact(IContactRepository contactRepository)
			: base(contactRepository)
		{
			_contactRepository = contactRepository;
		}
	}
}