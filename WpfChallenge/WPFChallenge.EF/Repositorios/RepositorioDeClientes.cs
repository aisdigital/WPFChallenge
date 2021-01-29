using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Dominio.Clientes;

namespace WPFChallenge.EF.Repositorios
{
    public class RepositorioDeClientes : IRepositorioDeClientes
    {
        private readonly Contexto _contexto;

        public RepositorioDeClientes(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Cliente BuscarPorId(int id)
        {
            return this._contexto.Set<Cliente>().SingleOrDefault(a => a.Id == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            this._contexto.Set<Cliente>().Add(cliente);
        }

        public void Excluir(Cliente cliente)
        {
            this._contexto.Set<Cliente>().Remove(cliente);
        }

        public List<Cliente> Listar()
        {
            return this._contexto.Set<Cliente>().ToList();
        }
    }
}
