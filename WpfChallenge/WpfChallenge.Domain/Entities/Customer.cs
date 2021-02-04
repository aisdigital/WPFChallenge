using WpfChallenge.Domain.Entities.Base;
using WpfChallenge.Domain.ValueObjects;

namespace WpfChallenge.Domain.Entities
{
    public class Customer : EntityBase
    {
        protected Customer()
        {

        }

        public Customer(string name, Email email, Phone phone, Address address)
        {
            Name = name;
            Email = email.EmailAddress;
            Phone = phone.PhoneNumber;
            Street = address.Street;
            Number = address.Number;
            Neighborhood = address.Neighborhood;
            City = address.City;
            State = address.State;
            Country = address.Country;
            ZipCode = address.ZipCode;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }


        public void Update(string name, Email email, Phone phone, Address address)
        {
            Name = name;
            if (string.IsNullOrEmpty(Name))
            {
                AddNotification("Name", "Informe um nome válido");
            }
            Email = email.EmailAddress;
            Phone = phone.PhoneNumber;
            Street = address.Street;
            Number = address.Number;
            Neighborhood = address.Neighborhood;
            City = address.City;
            State = address.State;
            Country = address.Country;
            ZipCode = address.ZipCode;
        }
    }
}
