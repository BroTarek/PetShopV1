
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;

namespace PetShop.BackendV2.Application.Services;

public class AdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    

    public AdminService(IUserRepository userRepository,IPostRepository _postRepository)
    {
        _postRepository=_postRepository;
        _userRepository = userRepository;
        
    }

    public async Task<User> ApproveUserCreation(User user)
    {
        return await _userRepository.updateAccountStatus(user, AccountStatus.APPROVED);
    }

    public async Task<User> RejectUserCreation(User user)
    {
        return await _userRepository.updateAccountStatus(user, AccountStatus.REJECTED);
    }

    public async Task<User?> ApprovePostCreation(Post post)
    {
        return await _userRepository.updatePostStatus(post, PostStatus.APPROVED);
    }

    public async Task<User?> RejectPostCreation(Post post)
    {
        return await _userRepository.updatePostStatus(post, PostStatus.REJECTED);
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

    public async Task<List<Post>> DeletePostAsync(string postId)
    {
        return await _userRepository.DeletePostAsync(postId);
    }

    public async Task<List<Post>> DeleteUserAsync(string userId)
    {
        return await _userRepository.DeleteUserAsync(userId);
    }
    
}
