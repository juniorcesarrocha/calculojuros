using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace CalculoJuros.Infrastructure.Notifications
{
    public class RequestNotificator : IRequestNotificator
    {
        private List<Notification> _notifications;

        public RequestNotificator() 
        {
            _notifications = new List<Notification>();
        }
        public void Add(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void Add(ValidationResult notifications)
        {
            var errorMessages = notifications.Errors.SelectMany(x => x.ErrorMessage);
            foreach (var error in notifications.Errors)
            {
                _notifications.Add(new Notification(error.ErrorMessage));
            }
        }

        public void Add(IEnumerable<string> notifications)
        {
            foreach (var error in notifications)
            {
               _notifications.Add(new Notification(error));
            }
        }

        public void Add(string notification)
        {
            _notifications.Add(new Notification(notification));
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public List<Notification> Get()
        {
            return _notifications;
        }
    }
}