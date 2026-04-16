using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Domain.Interfaces.Repositories;

public interface IReviewRepository
{
    // CRUD Operations
    Task<Review> CreateAsync(Review review);
    Task<Review?> GetByIdAsync(string id);
    Task UpdateAsync(Review review);
    Task DeleteAsync(string id);
    
    // Query Methods
    Task<List<Review>> GetReviewsByReviewerIdAsync(string reviewerId);
    Task<List<Review>> GetReviewsByRevieweeIdAsync(string revieweeId);
    Task<Review?> GetReviewByReviewerAndRevieweeAsync(string reviewerId, string revieweeId);
   
   Task<int> GetReviewCountForUserAsync(string userId);
    Task<double> GetAverageRatingForUserAsync(string userId);
    
    // Validation
    Task<bool> UserHasReviewedUserAsync(string reviewerId, string revieweeId);
    Task<bool> ExistsAsync(string reviewId);
    
    // Bulk Operations
    Task DeleteAllReviewsByUserAsync(string userId);
    Task DeleteAllReviewsForUserAsync(string userId);
}
