namespace PetShop.BackendV2.Domain.Entities.ViewModels;

public class PetResponseVM
{
    public string PetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string HealthStatus { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> Images { get; set; } = new();
    public string Status { get; set; } = string.Empty;
    
    // Owner information
    public string OwnerId { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string OwnerEmail { get; set; } = string.Empty;
    
    // Timestamps
    public DateTime CreationDate { get; set; }
    public DateTime LastModified { get; set; }
    
    // Statistics
    public int ActiveAdoptionRequests { get; set; }
    public bool HasActivePost { get; set; }
    
    // Computed properties
    public string AgeText => Age == 1 ? "1 year" : $"{Age} years";
    public string DisplayName => $"{Name} - {Breed}";
    public string StatusColor => Status switch
    {
        "Available" => "green",
        "Adopted" => "blue",
        "Pending" => "orange",
        "Hold" => "red",
        _ => "gray"
    };
}

public class PetListResponseVM
{
    public string PetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Location { get; set; } = string.Empty;
    public string PrimaryImage { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
}