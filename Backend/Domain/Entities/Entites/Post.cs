using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Domain.Entities;

public class Post
{
    public string Id { get; set; } = string.Empty;
    
    // Post content
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
    // Associations
    public string PetId { get; set; } = string.Empty;
    public virtual Pet Pet { get; set; } = null!;
    
    public string UserId { get; set; } = string.Empty;
    public virtual User User { get; set; } = null!;
    
    // Timestamps
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public DateTime LastModified { get; set; } = DateTime.UtcNow;
    
    // Status
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    
    // Navigation properties
    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
}
