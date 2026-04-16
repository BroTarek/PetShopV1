public class UpdateReviewRequest
{
    public string ReviewerId { get; set; } = string.Empty;
    public string? Content { get; set; }
    public int? Rating { get; set; }
}
