using System;

namespace CalculoJuros.Infrastructure.Notifications
{
    public class Notification
    {
        public string Menssage { get; }
        public Notification(string message)
        {
            Menssage = message;
        }        
    }
}