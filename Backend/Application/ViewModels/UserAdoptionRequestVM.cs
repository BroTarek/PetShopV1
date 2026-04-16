namespace PetShop.BackendV2.Domain.Entities.ViewModels;

public class UserAdoptionRequestVM
{
    public string RequestId { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
    public string PetImageUrl { get; set; } = string.Empty;
    public string InitiatorName { get; set; } = string.Empty;
    public string InitiatorEmail { get; set; } = string.Empty;
    public string ReceiverName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public DateTime? DecisionDate { get; set; }
    public string PetHealthStatus { get; set; } = string.Empty;
    
    // Computed properties
    public string StatusColor => Status switch
    {
        "Pending" => "yellow",
        "Approved" => "green",
        "Rejected" => "red",
        "Cancelled" => "gray",
        _ => "blue"
    };
    
    public string DisplayText => Status switch
    {
        "Pending" => $"{InitiatorName} requested to adopt {PetName}",
        "Approved" => $"{PetName} was adopted by {InitiatorName}",
        "Rejected" => $"Adoption request for {PetName} was rejected",
        "Cancelled" => $"Adoption request for {PetName} was cancelled",
        _ => $"Adoption request for {PetName}"
    };
    
    public bool IsPending => Status == "Pending";
    public bool IsApproved => Status == "Approved";
    public bool IsRejected => Status == "Rejected";
    public bool IsCancelled => Status == "Cancelled";
}
