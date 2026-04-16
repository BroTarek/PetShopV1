using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.Application.Interfaces.VMRepos;

public interface IUserAdoptionVMRepo
{
    // Returns ViewModels for display - READ ONLY
    Task<List<UserAdoptionRequestVM>> GetInitiatedRequestsVMAsync(string userId);
    Task<List<UserAdoptionRequestVM>> GetReceivedRequestsVMAsync(string userId);
    Task<UserAdoptionRequestVM?> GetRequestByIdVMAsync(string requestId);
    Task<List<UserAdoptionRequestVM>> GetAllPendingRequestsVMAsync();
}
