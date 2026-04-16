
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;

namespace PetShop.BackendV2.Application.Services;

public class AdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    

    public AdminService(IUserRepository userRepository, IPostRepository postRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }


    private async Task<User?> UpdateUserStatusAsync(string userId, AccountStatus status)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user != null)
        {
            user.AccountStatus = status;
            await _userRepository.UpdateAsync(user);
        }
        return user;
    }

    public async Task<User?> ActivateUserAsync(string userId)
    {
        return await UpdateUserStatusAsync(userId, AccountStatus.Approved);
    }

    public async Task<User?> DeactivateUserAsync(string userId)
    {
        return await UpdateUserStatusAsync(userId, AccountStatus.Rejected);
    }

    public async Task<User?> ApproveUserCreation(string userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user != null) {
            user.AccountStatus = AccountStatus.Approved;
            await _userRepository.UpdateAsync(user);
        }
        return user;
    }

    public async Task<User?> RejectUserCreation(string userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user != null) {
            user.AccountStatus = AccountStatus.Rejected;
            await _userRepository.UpdateAsync(user);
        }
        return user;
    }
    
    public async Task<User?> SuspendUserAsync(string userId)
    {
        return await UpdateUserStatusAsync(userId, AccountStatus.Suspended);
    }

    public async Task<Post?> ApprovePostCreation(string postId)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        if (post != null) {
            post.IsActive = true;
            await _postRepository.UpdateAsync(post);
        }
        return post;
    }

    public async Task<Post?> RejectPostCreation(string postId)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        if (post != null) {
            post.IsActive = false;
            post.IsDeleted = true;
            await _postRepository.UpdateAsync(post);
        }
        return post;
    }

    public async Task<object> GetDashboardStatisticsAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        var posts = await _postRepository.GetAllPostsAsync();
        
        return new {
            TotalUsers = users.Count,
            TotalPosts = posts.Count
        };
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }

    public async Task<List<User>> GetAllPendingUsers()
    {
        return await _userRepository.GetAllPendingUsers();
    }

    public async Task<List<Post>> GetAllPendingPosts()
    {
        return await _postRepository.GetAllPendingPosts();
    }

    public async Task DeletePostAsync(string postId)
    {
        await _postRepository.DeleteAsync(postId);
    }

    public async Task DeleteUserAsync(string userId)
    {
        await _userRepository.DeleteAsync(userId);
    }
}
