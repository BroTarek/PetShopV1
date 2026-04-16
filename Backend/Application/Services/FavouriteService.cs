using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Interfaces.Repositories;

namespace PetShop.BackendV2.Application.Services;

public class FavouriteService
{
    private readonly IFavouriteRepository _favouriteRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;

    public FavouriteService(
        IFavouriteRepository favouriteRepository,
        IUserRepository userRepository,
        IPostRepository postRepository)
    {
        _favouriteRepository = favouriteRepository;
        _userRepository = userRepository;
        _postRepository = postRepository;
    }

    public async Task<Favourite> AddPostToFavouritesAsync(string userId, string postId)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");
        
        // Validate post exists
        var post = await _postRepository.GetByIdAsync(postId);
        if (post == null)
            throw new KeyNotFoundException($"Post with ID {postId} not found");
        
        // Check if already favourited
        var exists = await _favouriteRepository.ExistsAsync(userId, postId);
        if (exists)
            throw new InvalidOperationException("User has already favourited this post");
        
        // Create favourite
        var favourite = new Favourite
        {
            Id = Guid.NewGuid().ToString(),
            UserId = userId,
            User = user,
            PostId = postId,
            Post = post,
            CreatedAt = DateTime.UtcNow
        };
        
        return await _favouriteRepository.CreateAsync(favourite);
    }
    
    public async Task RemovePostFromUserFavouritesAsync(string userId, string favouriteId)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");
        
        // Get favourite
        var favourite = await _favouriteRepository.GetByIdAsync(favouriteId);
        if (favourite == null)
            throw new KeyNotFoundException($"Favourite with ID {favouriteId} not found");
        
        // Verify ownership
        if (favourite.UserId != userId)
            throw new UnauthorizedAccessException("Cannot remove another user's favourite");
        
        await _favouriteRepository.DeleteAsync(favouriteId);
    }
    
    public async Task<List<Favourite>> GetPostsFavouritedByUserAsync(string userId)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");
        
        return await _favouriteRepository.GetFavouritesByUserIdAsync(userId);
    }
    
    public async Task<Favourite?> GetFavouriteByUserAndPostAsync(string userId, string postId)
    {
        return await _favouriteRepository.GetFavouriteByUserAndPostAsync(userId, postId);
    }
    
    public async Task<bool> HasUserFavouritedPostAsync(string userId, string postId)
    {
        return await _favouriteRepository.ExistsAsync(userId, postId);
    }
    
    public async Task<int> GetFavouriteCountForPostAsync(string postId)
    {
        return await _favouriteRepository.GetFavouriteCountByPostAsync(postId);
    }
    
    public async Task ClearAllFavouritesOfUserAsync(string userId)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");
        
        await _favouriteRepository.DeleteAllByUserIdAsync(userId);
    }
    
    public async Task<List<Favourite>> GetFavouritesWithDetailsAsync(string userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");
        
        return await _favouriteRepository.GetFavouritesWithIncludesAsync(userId);
    }
}
