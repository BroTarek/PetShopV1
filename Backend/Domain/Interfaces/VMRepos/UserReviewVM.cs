using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.Domain.Interfaces.VMRepos;

public interface IUserReviewVMRepo
{
    Task<List<ReviewResponseVM>> GetAllReviewsWrittenByUserAsync(string userId);
    Task<List<ReviewResponseVM>> GetAllReviewsReceivedByUserAsync(string userId);
}