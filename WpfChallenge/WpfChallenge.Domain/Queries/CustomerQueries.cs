using Flunt.Notifications;
using System;
using System.Linq;
using System.Threading.Tasks;
using WpfChallenge.Domain.Commands;
using WpfChallenge.Domain.Interfaces;
using WpfChallenge.Domain.Interfaces.Command;

namespace WpfChallenge.Domain.Queries
{
    public class CustomerQueries : Notifiable, ICommandResult
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerQueries(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ICommandResult> GetAll()
        {
            var listOfproducts = _customerRepository.List().ToList().OrderBy(x => x.Name);

            return listOfproducts != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", listOfproducts) : new CommandResult(false, "Dados não encontrados!", null);
        }

        public async Task<ICommandResult> Get(Guid id)
        {
            var product = _customerRepository.GetById(id);

            return product != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", product) : new CommandResult(false, "Dados não encontrados!", null);
        }
    }
}
