using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFChallenge.Dominio.Clientes
{
    public class Cliente : Entidade
    {
        public Cliente()
        {

        }

        public Cliente(string nome, string email, string telefone, string endereco) : this()
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome é obrigatório");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email é obrigatório");

            if (string.IsNullOrEmpty(telefone))
                throw new ArgumentException("Telefone é obrigatório");

            if (string.IsNullOrEmpty(endereco))
                throw new ArgumentException("Endereço é obrigatório");

            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Endereco = endereco;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }


        public void AlterarDados(string nome, string email, string telefone, string endereco)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome é obrigatório");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email é obrigatório");

            if (string.IsNullOrEmpty(telefone))
                throw new ArgumentException("Telefone é obrigatório");

            if (string.IsNullOrEmpty(endereco))
                throw new ArgumentException("Endereço é obrigatório");

            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Endereco = endereco;
        }
    }
}
