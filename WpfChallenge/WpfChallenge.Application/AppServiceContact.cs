using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Entities;
using WpfChallenge.Domain.Interfaces.Services;

namespace WpfChallenge.Application
{
	public class AppServiceContact : AppServiceBase<Contact>, IServiceContact
	{
		private readonly IServiceContact _contactService;

		public AppServiceContact(IServiceContact contactService)
		{
			_contactService = contactService;
		}
    }
}
