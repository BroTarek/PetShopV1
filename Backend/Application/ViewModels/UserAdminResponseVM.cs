using System;

namespace PetShop.BackendV2.Application.ViewModels;

public class UserAdminResponseVM
{
    public string UserId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string AccountStatus { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int TotalPets { get; set; }
    public int TotalPosts { get; set; }
    public int TotalReviewsGiven { get; set; }
    public int TotalReviewsReceived { get; set; }
}
