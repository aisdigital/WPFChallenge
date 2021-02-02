using WpfChallenge.Domain.Entities;
using WpfChallenge.Domain.Interfaces.Services;

namespace WpfChallenge.Application
{
	public class AppServiceContact : AppServiceBase<Contact>, IServiceContact
	{
		private readonly IServiceContact _contactService;

		public AppServiceContact(IServiceContact contactService)
			: base(contactService)
		{
			_contactService = contactService;
		}
	}
}