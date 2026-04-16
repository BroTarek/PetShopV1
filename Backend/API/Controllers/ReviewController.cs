using Microsoft.AspNetCore.Mvc;
using PetShop.BackendV2.Application.Services;
using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewRequest request)
    {
        try
        {
            var review = await _reviewService.CreateReviewAsync(request);
            
            return Ok(new
            {
                Success = true,
                Message = "Review created successfully",
                ReviewId = review.Id,
                CreatedAt = review.CreatedAt
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Success = false, Error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { Success = false, Error = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpPut("update/{reviewId}")]
    public async Task<IActionResult> UpdateReview(string reviewId, [FromBody] UpdateReviewRequest request)
    {
        try
        {
            var review = await _reviewService.UpdateReviewContentAsync(reviewId, request);
            
            return Ok(new
            {
                Success = true,
                Message = "Review updated successfully",
                ReviewId = review.Id,
                ModifiedAt = review.ModificationDate
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Success = false, Error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpDelete("delete/{reviewId}")]
    public async Task<IActionResult> DeleteReview(string reviewId, [FromQuery] string reviewerId)
    {
        try
        {
            await _reviewService.DeleteReviewAsync(reviewId, reviewerId);
            
            return Ok(new
            {
                Success = true,
                Message = "Review deleted successfully"
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Success = false, Error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("{reviewId}")]
    public async Task<IActionResult> GetReviewById(string reviewId)
    {
        try
        {
            var review = await _reviewService.GetReviewByIdAsync(reviewId);
            
            var response = new ReviewResponseVM
            {
                ReviewId = review.Id,
                Content = review.Content,
                Rating = review.Rating,
                ReviewerId = review.ReviewerId,
                ReviewerName = $"{review.Reviewer?.FirstName} {review.Reviewer?.LastName}",
                RevieweeId = review.RevieweeId,
                RevieweeName = $"{review.Reviewee?.FirstName} {review.Reviewee?.LastName}",
                CreatedAt = review.CreatedAt,
                ModificationDate = review.ModificationDate
            };
            
            return Ok(new { Success = true, Review = response });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("user/{userId}/given")]
    public async Task<IActionResult> GetReviewsGivenByUser(string userId)
    {
        try
        {
            var reviews = await _reviewService.GetReviewsByReviewerAsync(userId);
            
            var response = reviews.Select(review => new ReviewResponseVM
            {
                ReviewId = review.Id,
                Content = review.Content,
                Rating = review.Rating,
                ReviewerId = review.ReviewerId,
                ReviewerName = $"{review.Reviewer?.FirstName} {review.Reviewer?.LastName}",
                RevieweeId = review.RevieweeId,
                RevieweeName = $"{review.Reviewee?.FirstName} {review.Reviewee?.LastName}",
                CreatedAt = review.CreatedAt,
                ModificationDate = review.ModificationDate
            });
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                TotalReviews = response.Count(),
                Reviews = response
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("user/{userId}/received")]
    public async Task<IActionResult> GetReviewsReceivedByUser(string userId)
    {
        try
        {
            var reviews = await _reviewService.GetReviewsByRevieweeAsync(userId);
            
            var response = reviews.Select(review => new ReviewResponseVM
            {
                ReviewId = review.Id,
                Content = review.Content,
                Rating = review.Rating,
                ReviewerId = review.ReviewerId,
                ReviewerName = $"{review.Reviewer?.FirstName} {review.Reviewer?.LastName}",
                RevieweeId = review.RevieweeId,
                RevieweeName = $"{review.Reviewee?.FirstName} {review.Reviewee?.LastName}",
                CreatedAt = review.CreatedAt,
                ModificationDate = review.ModificationDate
            });
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                TotalReviews = response.Count(),
                Reviews = response
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

   
   

 
 


}
