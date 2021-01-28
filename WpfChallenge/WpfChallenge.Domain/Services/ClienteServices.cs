using System;
using System.Collections.Generic;
using System.Text;
using WpfChallenge.Domain.Interfaces.Repository;
using WpfChallenge.Domain.Interfaces.Services;
using WpfChallenge.Domain.Models;
using WpfChallenge.Domain.Util;

namespace WpfChallenge.Domain.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente GetCliente(int id)
        {
            try
            {
                var cliente = _clienteRepository.GetCliente(id);
                if (cliente != null)
                {
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<Cliente> ListCliente()
        {
            try
            {
                List<Cliente> listCliente = _clienteRepository.ListCliente();
                return listCliente;

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public Result Save(Cliente cliente)
        {
            try
            {
                var isValid = cliente.Validate(cliente);
                if (isValid.Success)
                {
                    _clienteRepository.Save(cliente);

                    return new Result(
                        true,
                        "O Cliente cadastrado com sucesso!",
                        null);
                }

                return new Result(false, isValid.Message, isValid.Data);

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public Result Update(Cliente cliente)
        {
            try
            {

                cliente.Telefone = !string.IsNullOrEmpty(cliente.Telefone) ? cliente.Telefone.Replace("(", "").Replace(")", "").Replace("-", "") : cliente.Telefone;
                _clienteRepository.Update(cliente);

                return new Result(
                    true,
                    "O cliente foi alterado com sucesso",
                    String.Empty);
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        public Result Delete(int id)
        {
            try
            {
                _clienteRepository.Delete(id);

                return new Result(
                        true,
                        "O Cliente excluído com sucesso!"
                        , String.Empty);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
