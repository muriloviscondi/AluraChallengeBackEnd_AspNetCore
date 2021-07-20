using prmToolkit.NotificationPattern;
using System;

namespace AluraChallenge.Domain.Entities.Base
{
    public class BaseEntity : Notifiable
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString(); ;
            CreateAt = DateTime.UtcNow;
        }

        public string Id { get; private set; }

        public DateTime CreateAt { get; protected set; }
    }
}
