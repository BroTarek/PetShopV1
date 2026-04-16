namespace PetShop.BackendV2.Domain.Entities.ViewModels;

public class PostResponseVM
{
    public string PostId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
    // Pet information
    public string PetId { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
    public string PetImageUrl { get; set; } = string.Empty;
    public string PetBreed { get; set; } = string.Empty;
    
    // User information
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    
    // Post metadata
    public DateTime CreationDate { get; set; }
    public DateTime LastModified { get; set; }
    public bool IsActive { get; set; }
    
    // Statistics
    public int FavouriteCount { get; set; }
    
    // Computed properties
    public string TimeAgo => GetTimeAgo(CreationDate);
    public string LastEditedTimeAgo => GetTimeAgo(LastModified);
    
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