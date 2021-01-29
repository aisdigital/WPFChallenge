using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFChallenge.Aplicacao.GestaoDeClientes.Modelos
{
    public class ModeloDeCadastroDeCliente
    {
        public ModeloDeCadastroDeCliente()
        {

        }
        public ModeloDeCadastroDeCliente(string nome, string email, string telefone, string endereco) : this()
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Endereco = endereco;
        }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }

        public string Endereco { get; private set; }
    }
}
