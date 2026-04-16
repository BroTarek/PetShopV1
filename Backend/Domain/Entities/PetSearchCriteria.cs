using PetShop.BackendV2.Domain.Enums;

namespace PetShop.BackendV2.Domain.Entities;

// Search Criteria DTO
public class PetSearchCriteria
{
    public string? Type { get; set; }
    public string? Breed { get; set; }
    public string? Location { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public Gender? Gender { get; set; }
    public HealthStatus? HealthStatus { get; set; }
    public PetStatus? Status { get; set; }
}
