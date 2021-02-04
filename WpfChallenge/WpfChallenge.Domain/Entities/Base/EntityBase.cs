using Flunt.Notifications;
using System;

namespace WpfChallenge.Domain.Entities.Base
{
    public class EntityBase : Notifiable
    {
        public Guid Id { get; private set; }
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
