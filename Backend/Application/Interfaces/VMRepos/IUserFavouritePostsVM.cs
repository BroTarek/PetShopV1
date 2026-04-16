using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.Application.Interfaces.VMRepos;

public interface IUserFavouritePostsVM
{
    Task<List<PostResponseVM>> GetAllFavouritePostsOfUserAsync(string userId);
}
