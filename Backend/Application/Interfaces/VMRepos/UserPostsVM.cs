using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.Application.Interfaces.VMRepos;

public interface IUserPostsVMRepo
{
    Task<List<PostResponseVM>> GetAllUsersPostsAsync(string userId);
}
