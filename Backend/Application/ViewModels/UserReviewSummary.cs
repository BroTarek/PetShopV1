using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Application.ViewModels;

public class UserReviewSummary
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public double AverageRating { get; set; }
    public int TotalReviews { get; set; }
    public Dictionary<int, int> RatingDistribution { get; set; } = new();
    public List<Review> RecentReviews { get; set; } = new();
}
