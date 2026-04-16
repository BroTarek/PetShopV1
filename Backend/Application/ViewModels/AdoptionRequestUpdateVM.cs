namespace PetShop.BackendV2.Application.ViewModels;

public class AdoptionRequestUpdateVM
{
    public string RequestId { get; set; }
    public string PetId { get; set; }
    public string PetName { get; set; }
    public string InitiatorId { get; set; }
    public string InitiatorName { get; set; }
    public string ReceiverId { get; set; }
    public string ReceiverName { get; set; }
    public string Status { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? DecisionDate { get; set; }
    public string Message { get; set; }
    public string UpdateType { get; set; } // "New", "Accepted", "Rejected", "Cancelled"
}