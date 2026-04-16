using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Domain.Interfaces.Repositories;

public interface IAdoptionRequestRepository
{
    // CRUD Operations
    Task<AdoptionRequest> CreateAsync(AdoptionRequest request);
    Task<AdoptionRequest?> GetByIdAsync(string id);
    Task UpdateAsync(AdoptionRequest request);
    Task DeleteAsync(string id);
    
    // Query Methods
    Task<List<AdoptionRequest>> GetByInitiatorIdAsync(string initiatorId);
    Task<List<AdoptionRequest>> GetByReceiverIdAsync(string receiverId);
    Task<List<AdoptionRequest>> GetByPetIdAsync(string petId);
    Task<List<AdoptionRequest>> GetPendingRequestsAsync();
    Task<bool> ExistsPendingRequestForPetAsync(string petId, string initiatorId);
}
