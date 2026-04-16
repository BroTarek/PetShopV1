using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    // Basic CRUD Operations
    Task<User> CreateAsync(User user);
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByEmailAsync(string email);
    Task UpdateAsync(User user);
    Task DeleteAsync(string id);
    
    // Advanced Queries with Includes
    Task<User?> GetByIdWithIncludesAsync(string id);
    Task<User?> GetByEmailWithIncludesAsync(string email);
    
    // Collection Navigation Properties
    Task<User?> GetUserWithPetsAsync(string userId);
    Task<User?> GetUserWithPostsAsync(string userId);
    Task<User?> GetUserWithReviewsMadeAsync(string userId);
    Task<User?> GetUserWithReviewsReceivedAsync(string userId);
    Task<User?> GetUserWithAdoptionRequestsInitiatedAsync(string userId);
    Task<User?> GetUserWithAdoptionRequestsReceivedAsync(string userId);
    Task<User?> GetUserWithFavouritesAsync(string userId);
    
    // Complete User with All Related Data
    Task<User?> GetUserWithAllRelatedDataAsync(string userId);
    
    // Collection Management Methods
    Task AddPetToUserAsync(string userId, Pet pet);
    Task RemovePetFromUserAsync(string userId, string petId);
    
    Task AddPostToUserAsync(string userId, Post post);
    Task RemovePostFromUserAsync(string userId, string postId);
    
    Task AddAdoptionRequestToInitiatorAsync(string userId, AdoptionRequest request);
    Task RemoveAdoptionRequestFromInitiatorAsync(string userId, string requestId);
    
    Task AddAdoptionRequestToReceiverAsync(string userId, AdoptionRequest request);
    Task RemoveAdoptionRequestFromReceiverAsync(string userId, string requestId);
    
    Task AddFavouriteToUserAsync(string userId, Favourite favourite);
    Task RemoveFavouriteFromUserAsync(string userId, string favouriteId);
    
    Task AddReviewToReviewsMadeAsync(string userId, Review review);
    Task RemoveReviewFromReviewsMadeAsync(string userId, string reviewId);
    
    Task AddReviewToReviewsReceivedAsync(string userId, Review review);
    Task RemoveReviewFromReviewsReceivedAsync(string userId, string reviewId);
    
    // Query Methods
    Task<List<User>> GetAllUsersAsync();
    Task<List<User>> GetUsersByRoleAsync(Role role);
    Task<List<User>> GetAllPendingUsers();
    Task<bool> UserExistsAsync(string userId);
    Task<bool> EmailExistsAsync(string email);
    
    // Bulk Operations
    Task UpdateUsersStatusAsync(List<string> userIds, AccountStatus status);
    Task<int> GetUserCountAsync();
}