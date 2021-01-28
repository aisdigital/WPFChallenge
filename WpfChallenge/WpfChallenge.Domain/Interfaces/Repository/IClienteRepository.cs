using System;
using System.Collections.Generic;
using System.Text;
using WpfChallenge.Domain.Models;
using WpfChallenge.Domain.Util;

namespace WpfChallenge.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Cliente GetCliente(int id);
        List<Cliente> ListCliente();
        void Save(Cliente cliente);
        void Delete(int id);
        void Update(Cliente cliente);

    }
}
