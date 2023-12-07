namespace DUNPLab.API.Models
{
    public class ATNotification
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsSent { get; set; }
        public ICollection<NotificationRecipient> Recipients { get; set; }
    }
}
