namespace DUNPLab.API.Services
{
    public class NotificationJob
    {
        private readonly NotificationService _notificationService;

        public NotificationJob(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void Execute()
        {
            _notificationService.CreateNotificationTableAndSend();
        }
    }
}
