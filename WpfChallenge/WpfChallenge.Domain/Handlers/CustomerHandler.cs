using Flunt.Notifications;
using System;
using System.Threading.Tasks;
using WpfChallenge.Domain.Commands;
using WpfChallenge.Domain.Commands.Customer;
using WpfChallenge.Domain.Entities;
using WpfChallenge.Domain.Interfaces;
using WpfChallenge.Domain.Interfaces.Command;
using WpfChallenge.Domain.Interfaces.Handler;
using WpfChallenge.Domain.ValueObjects;

namespace MyStockSys.Domain.Handlers
{
    public class CustomerHandler : Notifiable,
        IHandler<CreateCustomerCommand>,
        IHandler<UpdateCustomerCommand>,
         IHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ICommandResult> Handle(CreateCustomerCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            // Verificar se a entidade já está cadastrado
            if (_customerRepository.Exist(x => x.Name == command.Name))
            {
                AddNotification("Customer", "Já existe um cliente cadastrado com esse nome");
            }

            var email = new Email(command.Email);
            var phone = new Phone(command.Phone);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country,command.ZipCode);


            AddNotifications(email);
            AddNotifications(phone);
            AddNotifications(address);

            var newCustomer = new Customer(command.Name, email, phone, address);


            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _customerRepository.Add(newCustomer);

            // Retornar informações
            return new CommandResult(true, "Cadastro realizado com sucesso!", newCustomer);
        }

        public async Task<ICommandResult> Handle(UpdateCustomerCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            var customer = _customerRepository.GetById(command.Id);

            if (customer == null)
            {
                AddNotification("Customer", "Customer não cadastrada");
            }

            var email = new Email(command.Email);
            var phone = new Phone(command.Phone);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);


            AddNotifications(email);
            AddNotifications(phone);
            AddNotifications(address);

            customer.Update(command.Name, email, phone, address);


            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _customerRepository.Edit(customer);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", customer);
        }

        public async Task<ICommandResult> Handle(DeleteCustomerCommand command)
        {
            // Validar ID
            if (command.Id == Guid.Empty)
            {
                AddNotification("Id", "Parametro inválido.");
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            var product = _customerRepository.GetById(command.Id);

            // Verificar se Escola já está cadastrado
            if (product == null)
            {
                AddNotification("Customer", "Cliente não cadastrado");
               
            }

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível validar os dados.", this);

            // Escluindo a escola
            _customerRepository.Remove(product);

            // Retornar informações
            return new CommandResult(true, "Exclusão realizada com sucesso!", null);
        }
    }
}
