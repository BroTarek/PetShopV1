namespace PetShop.BackendV2.Application.ViewModels;

public class UserProfileVM
{
    public string UserId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string AccountStatus { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int TotalPets { get; set; }
    public int TotalPosts { get; set; }
    public int TotalReviewsGiven { get; set; }
    public int TotalReviewsReceived { get; set; }
    public int TotalFavourites { get; set; }
    public int TotalAdoptionRequestsInitiated { get; set; }
    public int TotalAdoptionRequestsReceived { get; set; }
}
