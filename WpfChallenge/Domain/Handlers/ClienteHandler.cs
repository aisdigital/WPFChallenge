using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Notifications;

namespace Domain.Handlers
{
    public class ClienteHandler : Notifiable
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public ICommandResult Handle(CadastrarClienteCommand command)
        {
            var cliente = new Cliente()
            {
                Nome = "Walisson de Oliveira Soares",
                Email = "walissonde@gmail..com",
                Telefone = "61998761639",
                CEP = "72110600",
                UF = "DF",
                Cidade = "Taguatinga",
                Bairro = "Taguatinga Norte",
                Logradouro = "Chacara 66b",
                Complemento = "Teste"
            };

            cliente.Cadastrar();
        
            _clienteRepository.Cadastrar(cliente);
            return null;
        }
    }
}
