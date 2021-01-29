using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFChallenge.Dominio.Clientes
{
    public interface IRepositorioDeClientes
    {
        void Cadastrar(Cliente cliente);

        Cliente BuscarPorId(int id);

        void Excluir(Cliente cliente);
        List<Cliente> Listar();
    }
}
