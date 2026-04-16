using PetShop.BackendV2.Domain.Enums;

namespace PetShop.BackendV2.Domain.Entities;

public class User
{
    public string Id { get; set; } = string.Empty;
    public AccountStatus Status { get; set; } = AccountStatus.PENDING;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }
    

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Reviews written BY this user (as reviewer)
    public virtual ICollection<Review> ReviewsMade { get; set; }=new List<Review>();

    // Reviews received BY this user (as reviewee)
    public virtual ICollection<Review> ReviewsReceived { get; set; }=new List<Review>();
    
    
    // Requests initiated BY this user (as the adopter)
    public virtual ICollection<AdoptionRequest> AdoptionRequestsInitiated { get; set; }

    // Requests received BY this user (as the pet owner)
    public virtual ICollection<AdoptionRequest> AdoptionRequestsReceived { get; set; }

    public List<Favourite> Favourites { get; set; } = new();
    
    public List<Pet> Pets{get;set;}=new();
    public List<Post> Posts{get;set;}=new();
}
