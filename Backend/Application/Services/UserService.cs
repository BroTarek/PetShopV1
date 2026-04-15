using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;

namespace PetShop.BackendV2.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly NotificationService _notificationService;

    public UserService(IUserRepository userRepository, NotificationService notificationService)
    {
        _userRepository = userRepository;
        _notificationService = notificationService;
    }

    public Task<User> CreateUserAsync(string firstName, string lastName, string email, string password, Role role) => throw new NotImplementedException();
    public Task<User> UpdateUserAsync(string userId, string firstName, string lastName, string email) => throw new NotImplementedException();
    public Task DeleteUserAsync(string userId) => throw new NotImplementedException();
    public Task ApproveAccountAsync(string userId) => throw new NotImplementedException();
    public Task RejectAccountAsync(string userId, string reason) => throw new NotImplementedException();
}
