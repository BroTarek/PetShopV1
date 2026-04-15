using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Infrastructure.Data;

namespace PetShop.BackendV2.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // Basic CRUD Operations
    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        return user;
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(string id)
    {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }
    }

    // Advanced Queries with Includes
    public async Task<User?> GetByIdWithIncludesAsync(string id)
    {
        return await _context.Users
            .Include(u => u.Pets)
            .Include(u => u.Posts)
            .Include(u => u.ReviewsMade)
            .Include(u => u.ReviewsReceived)
            .Include(u => u.AdoptionRequestsInitiated)
            .Include(u => u.AdoptionRequestsReceived)
            .Include(u => u.Favourites)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmailWithIncludesAsync(string email)
    {
        return await _context.Users
            .Include(u => u.Pets)
            .Include(u => u.Posts)
            .Include(u => u.ReviewsMade)
            .Include(u => u.ReviewsReceived)
            .Include(u => u.AdoptionRequestsInitiated)
            .Include(u => u.AdoptionRequestsReceived)
            .Include(u => u.Favourites)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    // Collection Navigation Properties
    public async Task<User?> GetUserWithPetsAsync(string userId)
    {
        return await _context.Users
            .Include(u => u.Pets)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetUserWithPostsAsync(string userId)
    {
        return await _context.Users
            .Include(u => u.Posts)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetUserWithReviewsMadeAsync(string userId)
    {
        return await _context.Users
            .Include(u => u.ReviewsMade)
            .ThenInclude(r => r.Reviewee)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetUserWithReviewsReceivedAsync(string userId)
    {
        return await _context.Users
            .Include(u => u.ReviewsReceived)
            .ThenInclude(r => r.Reviewer)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetUserWithAdoptionRequestsInitiatedAsync(string userId)
    {
        return await _context.Users
            .Include(u => u.AdoptionRequestsInitiated)
                .ThenInclude(ar => ar.Pet)
            .Include(u => u.AdoptionRequestsInitiated)
                .ThenInclude(ar => ar.Receiver)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetUserWithAdoptionRequestsReceivedAsync(string userId)
    {
        return await _context.Users
            .Include(u => u.AdoptionRequestsReceived)
                .ThenInclude(ar => ar.Pet)
            .Include(u => u.AdoptionRequestsReceived)
                .ThenInclude(ar => ar.Initiator)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetUserWithFavouritesAsync(string userId)
    {
        return await _context.Users
            .Include(u => u.Favourites)
                .ThenInclude(f => f.Post)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    // Complete User with All Related Data
    public async Task<User?> GetUserWithAllRelatedDataAsync(string userId)
    {
        return await _context.Users
            .Include(u => u.Pets)
            .Include(u => u.Posts)
                .ThenInclude(p => p.Pet)
            .Include(u => u.ReviewsMade)
                .ThenInclude(r => r.Reviewee)
            .Include(u => u.ReviewsReceived)
                .ThenInclude(r => r.Reviewer)
            .Include(u => u.AdoptionRequestsInitiated)
                .ThenInclude(ar => ar.Pet)
            .Include(u => u.AdoptionRequestsInitiated)
                .ThenInclude(ar => ar.Receiver)
            .Include(u => u.AdoptionRequestsReceived)
                .ThenInclude(ar => ar.Pet)
            .Include(u => u.AdoptionRequestsReceived)
                .ThenInclude(ar => ar.Initiator)
            .Include(u => u.Favourites)
                .ThenInclude(f => f.Post)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    // Collection Management Methods
    public async Task AddPetToUserAsync(string userId, Pet pet)
    {
        var user = await GetUserWithPetsAsync(userId);
        if (user != null)
        {
            user.Pets ??= new List<Pet>();
            user.Pets.Add(pet);
            _context.Users.Update(user);
        }
    }

    public async Task RemovePetFromUserAsync(string userId, string petId)
    {
        var user = await GetUserWithPetsAsync(userId);
        if (user?.Pets != null)
        {
            var pet = user.Pets.FirstOrDefault(p => p.Id == petId);
            if (pet != null)
            {
                user.Pets.Remove(pet);
                _context.Users.Update(user);
            }
        }
    }

    public async Task AddPostToUserAsync(string userId, Post post)
    {
        var user = await GetUserWithPostsAsync(userId);
        if (user != null)
        {
            user.Posts ??= new List<Post>();
            user.Posts.Add(post);
            _context.Users.Update(user);
        }
    }

    public async Task RemovePostFromUserAsync(string userId, string postId)
    {
        var user = await GetUserWithPostsAsync(userId);
        if (user?.Posts != null)
        {
            var post = user.Posts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                user.Posts.Remove(post);
                _context.Users.Update(user);
            }
        }
    }

    public async Task AddAdoptionRequestToInitiatorAsync(string userId, AdoptionRequest request)
    {
        var user = await GetUserWithAdoptionRequestsInitiatedAsync(userId);
        if (user != null)
        {
            user.AdoptionRequestsInitiated ??= new List<AdoptionRequest>();
            user.AdoptionRequestsInitiated.Add(request);
            _context.Users.Update(user);
        }
    }

    public async Task RemoveAdoptionRequestFromInitiatorAsync(string userId, string requestId)
    {
        var user = await GetUserWithAdoptionRequestsInitiatedAsync(userId);
        if (user?.AdoptionRequestsInitiated != null)
        {
            var request = user.AdoptionRequestsInitiated.FirstOrDefault(ar => ar.Id == requestId);
            if (request != null)
            {
                user.AdoptionRequestsInitiated.Remove(request);
                _context.Users.Update(user);
            }
        }
    }

    public async Task AddAdoptionRequestToReceiverAsync(string userId, AdoptionRequest request)
    {
        var user = await GetUserWithAdoptionRequestsReceivedAsync(userId);
        if (user != null)
        {
            user.AdoptionRequestsReceived ??= new List<AdoptionRequest>();
            user.AdoptionRequestsReceived.Add(request);
            _context.Users.Update(user);
        }
    }

    public async Task RemoveAdoptionRequestFromReceiverAsync(string userId, string requestId)
    {
        var user = await GetUserWithAdoptionRequestsReceivedAsync(userId);
        if (user?.AdoptionRequestsReceived != null)
        {
            var request = user.AdoptionRequestsReceived.FirstOrDefault(ar => ar.Id == requestId);
            if (request != null)
            {
                user.AdoptionRequestsReceived.Remove(request);
                _context.Users.Update(user);
            }
        }
    }

    public async Task AddFavouriteToUserAsync(string userId, Favourite favourite)
    {
        var user = await GetUserWithFavouritesAsync(userId);
        if (user != null)
        {
            user.Favourites ??= new List<Favourite>();
            user.Favourites.Add(favourite);
            _context.Users.Update(user);
        }
    }

    public async Task RemoveFavouriteFromUserAsync(string userId, string favouriteId)
    {
        var user = await GetUserWithFavouritesAsync(userId);
        if (user?.Favourites != null)
        {
            var favourite = user.Favourites.FirstOrDefault(f => f.Id == favouriteId);
            if (favourite != null)
            {
                user.Favourites.Remove(favourite);
                _context.Users.Update(user);
            }
        }
    }

    // Query Methods
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<List<User>> GetUsersByRoleAsync(Role role)
    {
        return await _context.Users
            .Where(u => u.Role == role)
            .ToListAsync();
    }

    public async Task<List<User>> GetUsersByStatusAsync(AccountStatus status)
    {
        return await _context.Users
            .Where(u => u.AccountStatus == status)
            .ToListAsync();
    }

    public async Task<bool> UserExistsAsync(string userId)
    {
        return await _context.Users.AnyAsync(u => u.Id == userId);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    // Bulk Operations
    public async Task UpdateUsersStatusAsync(List<string> userIds, AccountStatus status)
    {
        var users = await _context.Users
            .Where(u => userIds.Contains(u.Id))
            .ToListAsync();
        
        foreach (var user in users)
        {
            user.AccountStatus = status;
        }
        
        _context.Users.UpdateRange(users);
    }

    public async Task<int> GetUserCountAsync()
    {
        return await _context.Users.CountAsync();
    }
}