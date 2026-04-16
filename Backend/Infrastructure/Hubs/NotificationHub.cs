using Microsoft.AspNetCore.SignalR;

namespace PetShop.BackendV2.Infrastructure.Hubs;

public class NotificationHub : Hub
{
    public async Task SendNotification(string userId, string message)
    {
        await Clients.User(userId).SendAsync("ReceiveNotification", message);
    }
}
