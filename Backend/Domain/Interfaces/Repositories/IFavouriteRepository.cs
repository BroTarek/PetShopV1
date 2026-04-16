using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Domain.Interfaces.Repositories;

public interface IFavouriteRepository
{
    // CRUD Operations
    Task<Favourite> CreateAsync(Favourite favourite);
    Task<Favourite?> GetByIdAsync(string id);
    Task DeleteAsync(string id);
    Task UpdateAsync(Favourite favourite);
    
    // Query Methods
    Task<List<Favourite>> GetFavouritesByUserIdAsync(string userId);
    Task<List<Favourite>> GetFavouritesByPostIdAsync(string postId);
    Task<Favourite?> GetFavouriteByUserAndPostAsync(string userId, string postId);
    Task<bool> ExistsAsync(string userId, string postId);
    Task<int> GetFavouriteCountByPostAsync(string postId);
    Task<int> GetFavouriteCountByUserAsync(string userId);
    
    // Bulk Operations
    Task DeleteAllByUserIdAsync(string userId);
    Task DeleteAllByPostIdAsync(string postId);
    Task<List<Favourite>> GetFavouritesWithIncludesAsync(string userId);
}
