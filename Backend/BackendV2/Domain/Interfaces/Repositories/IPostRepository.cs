using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Domain.Interfaces.Repositories;

public interface IPostRepository
{
    // CRUD Operations
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetByIdAsync(string id);
    Task UpdateAsync(Post post);
    Task DeleteAsync(string id);
    
    // Query Methods
    Task<List<Post>> GetPostsByUserIdAsync(string userId);
    Task<List<Post>> GetPostsByPetIdAsync(string petId);
    Task<List<Post>> GetAllPostsAsync();
    Task<List<Post>> GetActivePostsAsync();
    Task<Post?> GetPostWithDetailsAsync(string postId);
    
    Task<List<Post>> GetAllPendingPosts();
    // Validation
    Task<bool> ExistsAsync(string postId);
    Task<bool> UserOwnsPostAsync(string userId, string postId);
    
    // Bulk Operations
    Task DeleteAllByUserIdAsync(string userId);
    Task DeleteAllByPetIdAsync(string petId);
    
    // Count
    Task<int> GetPostCountByUserAsync(string userId);
    Task<int> GetPostCountByPetAsync(string petId);
}