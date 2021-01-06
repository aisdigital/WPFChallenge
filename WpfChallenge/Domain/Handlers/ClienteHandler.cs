using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Notifications;
using System;

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
            if (command.Validate())
            {
                var cliente = new Cliente()
                {
                    Nome = command.Nome,
                    Email = command.Email,
                    Telefone = command.Telefone,
                    CEP = command.CEP,
                    UF = command.UF,
                    Cidade = command.Cidade,
                    Bairro = command.Bairro,
                    Logradouro = command.Logradouro,
                    Complemento = command.Complemento
                };

                cliente.Cadastrar();

                _clienteRepository.Cadastrar(cliente);

                return new CommandResult(
                    true,
                    String.Empty,
                    "O cliente foi cadastrado com sucesso"
                );
            }

            return new CommandResult(false, string.Empty, command.Notifications);

        }

        public ICommandResult Handle(EditarClienteCommand command)
        {
            if (command.Validate())
            {
                var cliente = new Cliente()
                {
                    Id = command.Id,
                    Nome = command.Nome,
                    Email = command.Email,
                    Telefone = command.Telefone,
                    CEP = command.CEP,
                    UF = command.UF,
                    Cidade = command.Cidade,
                    Bairro = command.Bairro,
                    Logradouro = command.Logradouro,
                    Complemento = command.Complemento
                };

                cliente.Editar();

                _clienteRepository.Atualizar(cliente);

                return new CommandResult(
                    true,
                    String.Empty,
                    "O cliente foi alterado com sucesso"
                );
            }

            return new CommandResult(false, string.Empty, command.Notifications);

        }

    }
}
