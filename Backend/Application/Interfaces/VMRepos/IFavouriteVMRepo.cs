using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.Application.Interfaces.VMRepos;

public interface IFavouriteVMRepo
{
    Task<List<FavouriteResponseVM>> GetUserFavouritesWithDetailsAsync(string userId);
    Task<bool> IsPostFavouritedByUserAsync(string userId, string postId);
}
