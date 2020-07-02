using System.Collections.Generic;
using FluentValidation.Results;

namespace CalculoJuros.Infrastructure.Notifications
{
    public interface IRequestNotificator
    {
         bool HasNotification();
         void Add(Notification notification);
         void Add(ValidationResult notifications);
         void Add(IEnumerable<string> notifications);
         void Add(string notification);
         List<Notification> Get();
    }
}