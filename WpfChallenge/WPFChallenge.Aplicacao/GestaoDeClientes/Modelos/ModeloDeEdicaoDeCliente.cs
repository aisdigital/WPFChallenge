using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Dominio.Clientes;

namespace WPFChallenge.Aplicacao.GestaoDeClientes.Modelos
{
    public class ModeloDeEdicaoDeCliente
    {
        public ModeloDeEdicaoDeCliente()
        {

        }

        public ModeloDeEdicaoDeCliente(int id, string nome, string telefone, string endereco) : this()
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Endereco = endereco;
        }

        public ModeloDeEdicaoDeCliente(Cliente cliente) : this()
        {
            if (cliente == null)
                return;

            this.Id = cliente.Id;
            this.Nome = cliente.Nome;
            this.Telefone = cliente.Telefone;
            this.Endereco = cliente.Endereco;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }
    }
}
