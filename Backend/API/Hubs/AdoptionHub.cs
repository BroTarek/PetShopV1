using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using PetShop.BackendV2.Application.ViewModels;

namespace PetShop.BackendV2.API.Hubs;

[Authorize]
public class AdoptionHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> _userConnections = new();
    
    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier;
        if (!string.IsNullOrEmpty(userId))
        {
            _userConnections[userId] = Context.ConnectionId;
        }
        await base.OnConnectedAsync();
    }
    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.UserIdentifier;
        if (!string.IsNullOrEmpty(userId))
        {
            _userConnections.TryRemove(userId, out _);
        }
        await base.OnDisconnectedAsync(exception);
    }
    
    public async Task JoinRequestGroup(string requestId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"request-{requestId}");
    }
    
    public async Task LeaveRequestGroup(string requestId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"request-{requestId}");
    }
}