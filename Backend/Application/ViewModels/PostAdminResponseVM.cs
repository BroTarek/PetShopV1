using System;

namespace PetShop.BackendV2.Application.ViewModels;

public class PostAdminResponseVM
{
    public string PostId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
    public string PetType { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string OwnerEmail { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
