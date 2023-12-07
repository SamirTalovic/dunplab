namespace DUNPLab.API.Models
{
    public class NotificationRecipient
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string RecipientName { get; set; }

        public ATNotification Notification { get; set; }
    }
}
