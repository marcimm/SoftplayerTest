using System.Collections.Generic;
using System.Linq;

namespace MMM.Test.Core.Notifications
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification(NotificationType type)
        {
            return _notifications.Any(n => n.Type == type);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public List<string> GetMessages(NotificationType type)
        {
            return _notifications.Where(t => t.Type == type)
                .Select(m => m.Message).Distinct().Select(x => type + ": " + x).ToList();
        }
    }
}
