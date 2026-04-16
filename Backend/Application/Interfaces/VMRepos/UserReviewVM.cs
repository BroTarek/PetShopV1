using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.Application.Interfaces.VMRepos;

public interface IUserReviewVMRepo
{
    Task<List<ReviewResponseVM>> GetAllReviewsWrittenByUserAsync(string userId);
    Task<List<ReviewResponseVM>> GetAllReviewsReceivedByUserAsync(string userId);
}
