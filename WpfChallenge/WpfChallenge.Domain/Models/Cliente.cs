using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WpfChallenge.Domain.Interfaces;
using WpfChallenge.Domain.Util;

namespace WpfChallenge.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Result Validate(Cliente cliente)
        {

            if (string.IsNullOrEmpty(cliente.Nome))
            {
                return new Result(false, "Campo Nome não preenchido!", "Atencão");
            }

            if (string.IsNullOrEmpty(cliente.Email))
            {
                return new Result(false, "Campo E-mail não preenchido!", "Atencão");
            }
            else
            {
                string email = cliente.Email;
                Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (!rg.IsMatch(email))
                {
                    return new Result(false, "E-mail inválido!", "Atencão");
                }
            }

            if (string.IsNullOrEmpty(cliente.Telefone))
            {
                return new Result(false, "Campo Telefone não preenchido!", "Atencão");
            }
            if (string.IsNullOrEmpty(cliente.Endereco))
            {
                return new Result(false, "Campo Endereco não preenchido!", "Atencão");
            }

            return new Result(true, string.Empty, string.Empty);
        }
    }
}
