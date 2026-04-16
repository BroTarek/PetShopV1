namespace PetShop.BackendV2.Domain.Entities;

public class Review
{
    public string Id { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModificationDate { get; set; }

    // Associations
    
    public string ReviewerId { get; set; }
    public virtual User Reviewer { get; set; }

    public string RevieweeId { get; set; }
    public virtual User Reviewee { get; set; }

}
