using PetShop.BackendV2.Domain.Enums;

namespace PetShop.BackendV2.Domain.Entities;

public class Admin
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }
}
