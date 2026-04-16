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

    // ✅ Use UserRepository methods to add review to both users
    await _userRepository.AddReviewToReviewsMadeAsync(request.ReviewerId, review);
    await _userRepository.AddReviewToReviewsReceivedAsync(request.RevieweeId, review);

    // Save the review
    var createdReview = await _reviewRepository.CreateAsync(review);
    
    return createdReview;
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

    // ✅ Use UserRepository methods to remove review from both users
    await _userRepository.RemoveReviewFromReviewsMadeAsync(review.ReviewerId, reviewId);
    await _userRepository.RemoveReviewFromReviewsReceivedAsync(review.RevieweeId, reviewId);

    // Delete the review
    await _reviewRepository.DeleteAsync(reviewId);
}

    public async Task<Review> UpdateReviewContentAsync(string reviewId, UpdateReviewRequest request)
    {
        // Validate review exists (with includes to get user relationships)
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

    public async Task<UserReviewSummary> GetUserReviewSummaryAsync(string userId)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found");

        var averageRating = await _reviewRepository.GetAverageRatingForUserAsync(userId);
        var totalReviews = await _reviewRepository.GetReviewCountForUserAsync(userId);
        var reviews = await _reviewRepository.GetReviewsByRevieweeIdAsync(userId);

        var ratingDistribution = new Dictionary<int, int>();
        for (int i = 1; i <= 5; i++)
        {
            ratingDistribution[i] = reviews.Count(r => r.Rating == i);
        }

        return new UserReviewSummary
        {
            UserId = userId,
            UserName = $"{user.FirstName} {user.LastName}",
            AverageRating = Math.Round(averageRating, 2),
            TotalReviews = totalReviews,
            RatingDistribution = ratingDistribution,
            RecentReviews = reviews.Take(5).ToList()
        };
    }

    public async Task<bool> HasUserReviewedUserAsync(string reviewerId, string revieweeId)
    {
        return await _reviewRepository.UserHasReviewedUserAsync(reviewerId, revieweeId);
    }

    public async Task<double> GetAverageRatingForUserAsync(string userId)
    {
        return await _reviewRepository.GetAverageRatingForUserAsync(userId);
    }

    public async Task<int> GetReviewCountForUserAsync(string userId)
    {
        return await _reviewRepository.GetReviewCountForUserAsync(userId);
    }
}

