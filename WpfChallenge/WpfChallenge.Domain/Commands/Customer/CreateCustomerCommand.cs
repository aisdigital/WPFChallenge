using Flunt.Notifications;
using Flunt.Validations;
using WpfChallenge.Domain.Interfaces.Command;

namespace WpfChallenge.Domain.Commands.Customer
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {

        public string Name { get; set; }
        public string Email { get;set; }
        public string Phone { get;  set; }
        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 255, "Nome", "Nome deve conter até 255 caracteres")
                 .HasMinLen(Street, 3, "Rua", "Rua deve conter pelo menos 3 caracteres")
                 .IsEmail(Email, "E-mail", "Informe um e-mail válido")
            );
        }
    }
}
