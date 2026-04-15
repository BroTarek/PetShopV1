namespace PetShop.BackendV2.Domain.Entities.ViewModels;

public class FavouriteResponseVM
{
    public string FavouriteId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string PostId { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
    public string PetImageUrl { get; set; } = string.Empty;
    public DateTime FavouritedAt { get; set; }
    
    // Post details
    public string PostTitle { get; set; } = string.Empty;
    public string PostContent { get; set; } = string.Empty;
    
    // Computed properties
    public string DisplayText => $"{UserName} favourited {PetName}";
    public string TimeAgo => GetTimeAgo(FavouritedAt);
    
    private string GetTimeAgo(DateTime date)
    {
        var timeSpan = DateTime.UtcNow - date;
        if (timeSpan.Days > 7) return $"{timeSpan.Days / 7} weeks ago";
        if (timeSpan.Days > 0) return $"{timeSpan.Days} days ago";
        if (timeSpan.Hours > 0) return $"{timeSpan.Hours} hours ago";
        if (timeSpan.Minutes > 0) return $"{timeSpan.Minutes} minutes ago";
        return "Just now";
    }
}