using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Application.Interfaces.Services;

public interface IAdoptionNotificationService
{
    Task NotifyNewRequestAsync(AdoptionRequest request, User initiator, User receiver, Pet pet);
    Task NotifyRequestAcceptedAsync(AdoptionRequest request, User initiator, User receiver, Pet pet);
    Task NotifyRequestRejectedAsync(AdoptionRequest request, User initiator, User receiver, Pet pet);
    Task NotifyRequestCancelledAsync(AdoptionRequest request, User initiator, User receiver, Pet pet);
}
