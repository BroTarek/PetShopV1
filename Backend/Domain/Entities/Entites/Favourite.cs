namespace PetShop.BackendV2.Domain.Entities;

public class Favourite
{
    public string Id { get; set; } = string.Empty;

    // Associations
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;

    public string PostId { get; set; } = string.Empty;
    public Post Post { get; set; } = null!;
}
