using PetShop.BackendV2.Domain.Enums;

namespace PetShop.BackendV2.Domain.Entities;

public class Pet
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string Location { get; set; } = string.Empty;

    public HealthStatus HealthStatus { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<string> Images { get; set; } = new();
    public PetStatus Status { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastModified { get; set; }

    // Associations
    public string OwnerId { get; set; } = string.Empty;
    public User Owner { get; set; } = null!;
    
    // All adoption requests for this pet
    public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; }
}
