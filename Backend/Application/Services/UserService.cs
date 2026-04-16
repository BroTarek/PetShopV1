using PetShop.BackendV2.Application.DTO;
using PetShop.BackendV2.Application.ViewModels;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;

namespace PetShop.BackendV2.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #region Basic CRUD Operations

    public async Task<User> CreateUserAsync(CreateUserRequest request)
    {
        // Validate email doesn't already exist
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
            throw new InvalidOperationException($"User with email {request.Email} already exists");

        // Validate password
        if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
            throw new ArgumentException("Password must be at least 6 characters long");

        // Create user
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = HashPassword(request.Password), // You should implement password hashing
            Role = request.Role,
            AccountStatus = AccountStatus.Pending, // New users start as pending
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return await _userRepository.CreateAsync(user);
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        var user = await _userRepository.GetByIdWithIncludesAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");

        return user;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailWithIncludesAsync(email);
        if (user == null)
            throw new KeyNotFoundException($"User with email {email} not found");

        return user;
    }

    public async Task<User> UpdateUserAsync(string userId, UpdateUserRequest request)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");

        // Update fields
        user.FirstName = request.FirstName ?? user.FirstName;
        user.LastName = request.LastName ?? user.LastName;
        
        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            if (request.Password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long");
            user.Password = HashPassword(request.Password);
        }
        
        user.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
        return user;
    }

    public async Task DeleteUserAsync(string userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");

        await _userRepository.DeleteAsync(userId);
    }


    public async Task<User> UpdateUserStatusAsync(string userId, AccountStatus status)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");

        user.AccountStatus = status;
        user.UpdatedAt = DateTime.UtcNow;
        
        await _userRepository.UpdateAsync(user);
        return user;
    }


  
  
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<List<User>> GetUsersByRoleAsync(Role role)
    {
        return await _userRepository.GetUsersByRoleAsync(role);
    }

    public async Task<List<User>> GetAllPendingUsersAsync()
    {
        return await _userRepository.GetAllPendingUsers();
    }

    public async Task<bool> UserExistsAsync(string userId)
    {
        return await _userRepository.UserExistsAsync(userId);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _userRepository.EmailExistsAsync(email);
    }

    public async Task<int> GetUserCountAsync()
    {
        return await _userRepository.GetUserCountAsync();
    }

    #endregion

    #region User Profile Management

    public async Task<UserProfileVM> GetUserProfileAsync(string userId)
    {
        var user = await _userRepository.GetByIdWithIncludesAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");

        return new UserProfileVM
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role.ToString(),
            AccountStatus = user.AccountStatus.ToString(),
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            TotalPets = user.Pets?.Count ?? 0,
            TotalPosts = user.Posts?.Count ?? 0,
            TotalReviewsGiven = user.ReviewsMade?.Count ?? 0,
            TotalReviewsReceived = user.ReviewsReceived?.Count ?? 0,
            TotalFavourites = user.Favourites?.Count ?? 0,
            TotalAdoptionRequestsInitiated = user.AdoptionRequestsInitiated?.Count ?? 0,
            TotalAdoptionRequestsReceived = user.AdoptionRequestsReceived?.Count ?? 0
        };
    }

    public async Task<User> UpdateUserProfileAsync(string userId, UpdateUserProfileRequest request)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");

        user.FirstName = request.FirstName ?? user.FirstName;
        user.LastName = request.LastName ?? user.LastName;
        user.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
        return user;
    }


    #endregion
    
    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}

