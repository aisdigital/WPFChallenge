using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Core.Interfaces.Repositories;
using WpfChallenge.Domain.Entities;

namespace WpfChallenge.Domain.Service
{
	public class ServiceContact : ServiceBase<Contact>
	{
		private readonly IRepositoryContact repositoryContact;

		public ServiceContact(IRepositoryContact repositoryContact)
			: base(repositoryContact)
		{
			this.repositoryContact = repositoryContact;
		}
	}
}
