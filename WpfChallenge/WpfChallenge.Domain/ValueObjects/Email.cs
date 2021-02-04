using Flunt.Notifications;

namespace WpfChallenge.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string EmailAddress { get; private set; }

        protected Email()
        {

        }

        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;

            if (string.IsNullOrEmpty(EmailAddress))
            {
                AddNotification("Email", "O Campo email não pode ser nulo");
            }
        }
    }
}
