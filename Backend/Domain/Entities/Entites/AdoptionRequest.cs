using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;

namespace PetShop.BackendV2.Domain.Entities;

public class AdoptionRequest
{
    public string Id { get; set; } = string.Empty;
    public AdoptionStatus Status { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? DecisionDate { get; set; }

    // Associations
    public string PetId { get; set; } = string.Empty;
    public virtual Pet Pet { get; set; } = null!;

    // Initiator (user who wants to adopt)
    public string InitiatorId { get; set; } = string.Empty;
    public virtual User Initiator { get; set; } = null!;

    // Receiver (user who currently owns the pet)
    public string ReceiverId { get; set; } = string.Empty;
    public virtual User Receiver { get; set; } = null!;
}
