using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Interfaces.Repositories;

namespace PetShop.BackendV2.Application.Services;

public class ReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;

    public ReviewService(
        IReviewRepository reviewRepository,
        IUserRepository userRepository)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
    }

    public async Task<Review> CreateReviewAsync(CreateReviewRequest request)
    {
        // Validate reviewer exists
        var reviewer = await _userRepository.GetByIdAsync(request.ReviewerId);
        if (reviewer == null)
            throw new KeyNotFoundException($"Reviewer with ID {request.ReviewerId} not found");

        // Validate reviewee exists
        var reviewee = await _userRepository.GetByIdAsync(request.RevieweeId);
        if (reviewee == null)
            throw new KeyNotFoundException($"Reviewee with ID {request.RevieweeId} not found");

        // Prevent self-review
        if (request.ReviewerId == request.RevieweeId)
            throw new InvalidOperationException("Users cannot review themselves");

        // Check for duplicate review
        var existingReview = await _reviewRepository.GetReviewByReviewerAndRevieweeAsync(
            request.ReviewerId, request.RevieweeId);
        
        if (existingReview != null)
            throw new InvalidOperationException("You have already reviewed this user");

        // Validate rating
        if (request.Rating < 1 || request.Rating > 5)
            throw new ArgumentException("Rating must be between 1 and 5");

        // Create review
        var review = new Review
        {
            Id = Guid.NewGuid().ToString(),
            Content = request.Content,
            Rating = request.Rating,
            ReviewerId = request.ReviewerId,
            Reviewer = reviewer,
            RevieweeId = request.RevieweeId,
            Reviewee = reviewee,
            CreatedAt = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow
        };

        return await _reviewRepository.CreateAsync(review);
    }

    public async Task<Review> UpdateReviewContentAsync(string reviewId, UpdateReviewRequest request)
    {
        // Validate review exists
        var review = await _reviewRepository.GetByIdAsync(reviewId);
        if (review == null)
            throw new KeyNotFoundException($"Review with ID {reviewId} not found");

        // Verify ownership (only reviewer can update)
        if (review.ReviewerId != request.ReviewerId)
            throw new UnauthorizedAccessException("You can only update your own reviews");

        // Update content
        review.Content = request.Content ?? review.Content;
        review.Rating = request.Rating ?? review.Rating;
        review.ModificationDate = DateTime.UtcNow;

        await _reviewRepository.UpdateAsync(review);
        return review;
    }

    public async Task DeleteReviewAsync(string reviewId, string reviewerId)
    {
        // Validate review exists
        var review = await _reviewRepository.GetByIdAsync(reviewId);
        if (review == null)
            throw new KeyNotFoundException($"Review with ID {reviewId} not found");

        // Verify ownership
        if (review.ReviewerId != reviewerId)
            throw new UnauthorizedAccessException("You can only delete your own reviews");

        await _reviewRepository.DeleteAsync(reviewId);
    }

    public async Task<Review> GetReviewByIdAsync(string reviewId)
    {
        var review = await _reviewRepository.GetByIdAsync(reviewId);
        if (review == null)
            throw new KeyNotFoundException($"Review with ID {reviewId} not found");

        return review;
    }

    public async Task<List<Review>> GetReviewsByReviewerAsync(string reviewerId)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(reviewerId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {reviewerId} not found");

        return await _reviewRepository.GetReviewsByReviewerIdAsync(reviewerId);
    }

    public async Task<List<Review>> GetReviewsByRevieweeAsync(string revieweeId)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(revieweeId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {revieweeId} not found");

        return await _reviewRepository.GetReviewsByRevieweeIdAsync(revieweeId);
    }

   
   

   
   
}

// Request DTOs
public class CreateReviewRequest
{
    public string ReviewerId { get; set; } = string.Empty;
    public string RevieweeId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; } // 1-5
}

public class UpdateReviewRequest
{
    public string ReviewerId { get; set; } = string.Empty;
    public string? Content { get; set; }
    public int? Rating { get; set; }
}

public class UserReviewSummary
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public double AverageRating { get; set; }
    public int TotalReviews { get; set; }
    public Dictionary<int, int> RatingDistribution { get; set; } = new();
    public List<Review> RecentReviews { get; set; } = new();
}