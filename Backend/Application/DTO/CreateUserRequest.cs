using PetShop.BackendV2.Domain.Enums;

namespace PetShop.BackendV2.Application.DTO;

public class CreateUserRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.Adopter;
}
