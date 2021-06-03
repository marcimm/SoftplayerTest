using System.Collections.Generic;

namespace MMM.Test.Core.Notifications
{
    public interface INotifier
    {
        bool HasNotification(NotificationType type);
        List<Notification> GetNotifications();
        List<string> GetMessages(NotificationType type);
        void Handle(Notification notification);
    }
}
