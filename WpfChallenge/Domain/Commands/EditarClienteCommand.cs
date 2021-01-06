﻿using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;
using System;

namespace Domain.Commands
{
    public class EditarClienteCommand : Notifiable, ICommand
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
        public int? Numero { get; set; }

        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                .IsEmail(Email, "Email", "O email informado é inválido"));

            return Valid;
        }
    }
}
