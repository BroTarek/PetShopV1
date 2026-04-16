using Microsoft.AspNetCore.SignalR;
using PetShop.BackendV2.API.Hubs;
using PetShop.BackendV2.Application.Interfaces.Services;
using PetShop.BackendV2.Application.ViewModels;
using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.API.Services;

public class AdoptionNotificationService : IAdoptionNotificationService
{
    private readonly IHubContext<AdoptionHub> _hubContext;

    public AdoptionNotificationService(IHubContext<AdoptionHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyNewRequestAsync(AdoptionRequest request, User initiator, User receiver, Pet pet)
    {
        var update = new AdoptionRequestUpdateVM
        {
            RequestId = request.Id,
            PetId = pet.Id,
            PetName = pet.Name ?? "Pet",
            InitiatorId = initiator.Id,
            InitiatorName = $"{initiator.FirstName} {initiator.LastName}",
            ReceiverId = receiver.Id,
            ReceiverName = $"{receiver.FirstName} {receiver.LastName}",
            Status = "Pending",
            RequestDate = request.RequestDate,
            UpdateType = "New",
            Message = $"New adoption request from {initiator.FirstName} {initiator.LastName} for {pet.Name}"
        };

        await _hubContext.Clients.User(receiver.Id).SendAsync("NewAdoptionRequest", update);
        await _hubContext.Clients.User(initiator.Id).SendAsync("RequestSent", update);
        await _hubContext.Clients.Group($"request-{request.Id}").SendAsync("RequestUpdate", update);
    }

    public async Task NotifyRequestAcceptedAsync(AdoptionRequest request, User initiator, User receiver, Pet pet)
    {
        var update = new AdoptionRequestUpdateVM
        {
            RequestId = request.Id,
            PetId = pet.Id,
            PetName = pet.Name ?? "Pet",
            InitiatorId = initiator.Id,
            InitiatorName = $"{initiator.FirstName} {initiator.LastName}",
            ReceiverId = receiver.Id,
            ReceiverName = $"{receiver.FirstName} {receiver.LastName}",
            Status = "Approved",
            RequestDate = request.RequestDate,
            DecisionDate = request.DecisionDate,
            UpdateType = "Accepted",
            Message = $"Your adoption request for {pet.Name} has been accepted!"
        };

        await _hubContext.Clients.User(initiator.Id).SendAsync("RequestAccepted", update);
        await _hubContext.Clients.User(receiver.Id).SendAsync("RequestProcessed", update);
        await _hubContext.Clients.Group($"request-{request.Id}").SendAsync("RequestUpdate", update);
    }

    public async Task NotifyRequestRejectedAsync(AdoptionRequest request, User initiator, User receiver, Pet pet)
    {
        var update = new AdoptionRequestUpdateVM
        {
            RequestId = request.Id,
            PetId = pet.Id,
            PetName = pet.Name ?? "Pet",
            InitiatorId = initiator.Id,
            InitiatorName = $"{initiator.FirstName} {initiator.LastName}",
            ReceiverId = receiver.Id,
            ReceiverName = $"{receiver.FirstName} {receiver.LastName}",
            Status = "Rejected",
            RequestDate = request.RequestDate,
            DecisionDate = request.DecisionDate,
            UpdateType = "Rejected",
            Message = $"Your adoption request for {pet.Name} has been rejected."
        };

        await _hubContext.Clients.User(initiator.Id).SendAsync("RequestRejected", update);
        await _hubContext.Clients.User(receiver.Id).SendAsync("RequestProcessed", update);
        await _hubContext.Clients.Group($"request-{request.Id}").SendAsync("RequestUpdate", update);
    }

    public async Task NotifyRequestCancelledAsync(AdoptionRequest request, User initiator, User receiver, Pet pet)
    {
        var update = new AdoptionRequestUpdateVM
        {
            RequestId = request.Id,
            PetId = pet.Id,
            PetName = pet.Name ?? "Pet",
            InitiatorId = initiator.Id,
            InitiatorName = $"{initiator.FirstName} {initiator.LastName}",
            ReceiverId = receiver.Id,
            ReceiverName = $"{receiver.FirstName} {receiver.LastName}",
            Status = "Cancelled",
            RequestDate = request.RequestDate,
            DecisionDate = request.DecisionDate,
            UpdateType = "Cancelled",
            Message = $"The adoption request for {pet.Name} has been cancelled."
        };

        await _hubContext.Clients.User(receiver.Id).SendAsync("RequestCancelled", update);
        await _hubContext.Clients.User(initiator.Id).SendAsync("RequestCancelled", update);
        await _hubContext.Clients.Group($"request-{request.Id}").SendAsync("RequestUpdate", update);
    }
}
