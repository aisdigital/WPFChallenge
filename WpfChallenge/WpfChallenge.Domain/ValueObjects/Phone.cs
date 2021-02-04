using Flunt.Validations;
using WpfChallenge.Domain.Entities.Base;

namespace WpfChallenge.Domain.ValueObjects
{
    public class Phone : EntityValueObjectBase
    {
        public string PhoneNumber { get; private set; }

        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;

            AddNotifications(new Contract()
                 .Requires().IsNotNullOrEmpty("Telefone", PhoneNumber, "A rua deve conter pelo menos 3 caracteres")
             );
        }
    }
}
