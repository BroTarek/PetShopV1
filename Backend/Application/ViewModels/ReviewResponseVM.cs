namespace PetShop.BackendV2.Domain.Entities.ViewModels;

public class ReviewResponseVM
{
    public string ReviewId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
    
    // Reviewer information
    public string ReviewerId { get; set; } = string.Empty;
    public string ReviewerName { get; set; } = string.Empty;
    public string ReviewerAvatar { get; set; } = string.Empty;
    
    // Reviewee information
    public string RevieweeId { get; set; } = string.Empty;
    public string RevieweeName { get; set; } = string.Empty;
    
    // Timestamps
    public DateTime CreatedAt { get; set; }
    public DateTime ModificationDate { get; set; }
    public string TimeAgo => GetTimeAgo(CreatedAt);
    public bool IsEdited => CreatedAt != ModificationDate;
    
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
