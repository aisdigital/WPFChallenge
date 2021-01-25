using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfChallenge.Domain.Interfaces.Repository;
using WpfChallenge.Domain.Models;
using WpfChallenge.Repository.Data;

namespace WpfChallenge.Repository.Repositorys
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Context dbContextCustom) : base(dbContextCustom)
        {
        }

        public void Save(Cliente cliente)
        {
            try
            {
                using (Context contexto = new Context())
                {
                    base.Insert(cliente);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public Cliente GetCliente(int id)
        {
            try
            {
                Cliente cliente = base.GetById(id);
                return cliente;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        List<Cliente> IClienteRepository.ListCliente()
        {
            try
            {
                List<Cliente> lstCliente = base.List().ToList();

                if (lstCliente.Count != 0)
                {
                    return lstCliente;
                }

                return null;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    Cliente clienteDB = base.GetById(id);
                    base.Delete(clienteDB);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                using (Context contexto = new Context())
                {
                    Cliente clienteDB = base.GetById(cliente.Id);
                    if (clienteDB != null)
                    {
                        clienteDB.Nome = cliente.Nome;
                        clienteDB.Nome = cliente.Email;
                        clienteDB.Nome = cliente.Telefone;
                        clienteDB.Nome = cliente.Endereco;
                    }

                    base.Update(clienteDB);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
