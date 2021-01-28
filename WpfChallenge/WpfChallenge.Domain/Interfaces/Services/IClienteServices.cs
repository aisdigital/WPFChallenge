using System;
using System.Collections.Generic;
using System.Text;
using WpfChallenge.Domain.Models;
using WpfChallenge.Domain.Util;

namespace WpfChallenge.Domain.Interfaces.Services
{
    public interface IClienteServices
    {
        Cliente GetCliente(int id);
        List<Cliente> ListCliente();
        Result Save(Cliente cliente);
        Result Delete(int id);
        Result Update(Cliente cliente);
    }
}
