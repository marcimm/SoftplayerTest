namespace MMM.Test.Core.Notifications
{
    public class Notification
    {
        public Notification(string message, NotificationType type)
        {
            Message = message;
            Type = type;
        }

        public Notification()
        { }

        public string Message { get; set; }

        public NotificationType? Type { get; set; }
    }
}
