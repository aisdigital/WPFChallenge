using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataEdicao { get; set; }

        public void Cadastrar()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }

        public void Editar()
        {
            DataEdicao = DateTime.Now;
        }
    }
}
