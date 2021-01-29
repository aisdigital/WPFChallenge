using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Dominio.Clientes;

namespace WPFChallenge.Dominio
{
    public interface IServicoDePersistencia
    {
        IRepositorioDeClientes RepositorioDeClientes { get; }

        void Persistir();
    }
}
