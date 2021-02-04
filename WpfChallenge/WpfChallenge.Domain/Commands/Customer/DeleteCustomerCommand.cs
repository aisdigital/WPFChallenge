using Flunt.Notifications;
using Flunt.Validations;
using System;
using WpfChallenge.Domain.Interfaces.Command;

namespace WpfChallenge.Domain.Commands.Customer
{
    public class DeleteCustomerCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
            );
        }
    }
}
