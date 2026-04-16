using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Domain.Interfaces.Repositories;

public interface IAdminRepository
{
    // Basic CRUD Operations
    Task<User> ApproveUserCreation(User user);
    Task<User> RejectUserCreation(User user);
    Task<User?> ApprovePostCreation(Post post);
    Task<User?> RejectPostCreation(Post post);
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetAllPendingUsers();
    Task<List<Post>> GetAllPendingPosts();
    Task<List<Post>> DeletePostAsync(string postId);
    Task<List<Post>> DeleteUserAsync(string userId);
    
    
    
}
