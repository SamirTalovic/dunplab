using DUNPLab.API.Infrastructure;
using DUNPLab.API.Models;
using DUNPLab.API.Services;
using Microsoft.AspNetCore.SignalR;

public class NotificationService 
{
    private readonly DunpContext _dbContext;
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(DunpContext dbContext, IHubContext<NotificationHub> hubContext)
    {
        _dbContext = dbContext;
        _hubContext = hubContext;
    }

    public void CreateNotificationTableAndSend()
    {
        _dbContext.Database.EnsureCreated();

        var unsentNotifications = _dbContext.Notifications.Where(n => !n.IsSent).ToList();

        foreach (var notification in unsentNotifications)
        {
            _hubContext.Clients.All.SendAsync("ReceiveNotification", notification.Text);
            var recipient = new NotificationRecipient { NotificationId = notification.Id, RecipientName = "Primaoc" };
            notification.Recipients = new List<NotificationRecipient> { recipient };
            Console.WriteLine(notification.Text);
            notification.IsSent = true;
            _dbContext.SaveChanges();
        }
    }
}
