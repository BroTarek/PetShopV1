using Microsoft.AspNetCore.Mvc;
using PetShop.BackendV2.Application.Services;
using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavouriteController : ControllerBase
{
    private readonly FavouriteService _favouriteService;

    public FavouriteController(FavouriteService favouriteService)
    {
        _favouriteService = favouriteService;
    }

    /// <summary>
    /// Add a post to user's favourites
    /// </summary>
    [HttpPost("add")]
    public async Task<IActionResult> AddToFavourites([FromBody] AddFavouriteRequest request)
    {
        try
        {
            var favourite = await _favouriteService.AddPostToFavouritesAsync(
                request.UserId, 
                request.PostId);
            
            return Ok(new
            {
                Success = true,
                Message = "Post added to favourites successfully",
                FavouriteId = favourite.Id,
                FavouritedAt = favourite.CreatedAt
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
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    /// <summary>
    /// Remove a post from user's favourites
    /// </summary>
    [HttpDelete("remove/{favouriteId}")]
    public async Task<IActionResult> RemoveFromFavourites(string favouriteId, [FromQuery] string userId)
    {
        try
        {
            await _favouriteService.RemovePostFromUserFavouritesAsync(userId, favouriteId);
            
            return Ok(new
            {
                Success = true,
                Message = "Post removed from favourites successfully"
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

    /// <summary>
    /// Get all favourites for a specific user
    /// </summary>
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserFavourites(string userId)
    {
        try
        {
            var favourites = await _favouriteService.GetPostsFavouritedByUserAsync(userId);
            
            // Convert to ViewModel for better response
            var response = favourites.Select(f => new
            {
                FavouriteId = f.Id,
                PostId = f.PostId,
                PetName = f.Post?.Pet?.Name ?? "Unknown Pet",
                FavouritedAt = f.CreatedAt,
                PostTitle = f.Post?.Title ?? string.Empty
            });
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                TotalFavourites = favourites.Count,
                Favourites = response
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

    /// <summary>
    /// Check if user has favourited a specific post
    /// </summary>
    [HttpGet("check")]
    public async Task<IActionResult> CheckFavourite([FromQuery] string userId, [FromQuery] string postId)
    {
        try
        {
            var hasFavourited = await _favouriteService.HasUserFavouritedPostAsync(userId, postId);
            var favourite = await _favouriteService.GetFavouriteByUserAndPostAsync(userId, postId);
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                PostId = postId,
                IsFavourited = hasFavourited,
                FavouriteId = favourite?.Id,
                FavouritedAt = favourite?.CreatedAt
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    /// <summary>
    /// Get favourite count for a post
    /// </summary>
    [HttpGet("post/{postId}/count")]
    public async Task<IActionResult> GetPostFavouriteCount(string postId)
    {
        try
        {
            var count = await _favouriteService.GetFavouriteCountForPostAsync(postId);
            
            return Ok(new
            {
                Success = true,
                PostId = postId,
                FavouriteCount = count
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    /// <summary>
    /// Clear all favourites for a user
    /// </summary>
    [HttpDelete("clear/{userId}")]
    public async Task<IActionResult> ClearAllFavourites(string userId)
    {
        try
        {
            await _favouriteService.ClearAllFavouritesOfUserAsync(userId);
            
            return Ok(new
            {
                Success = true,
                Message = "All favourites cleared successfully"
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

    /// <summary>
    /// Get detailed favourites with post and pet information
    /// </summary>
    [HttpGet("user/{userId}/detailed")]
    public async Task<IActionResult> GetUserFavouritesDetailed(string userId)
    {
        try
        {
            var favourites = await _favouriteService.GetFavouritesWithDetailsAsync(userId);
            
            var response = favourites.Select(f => new FavouriteResponseVM
            {
                FavouriteId = f.Id,
                UserId = f.UserId,
                UserName = $"{f.User?.FirstName} {f.User?.LastName}",
                PostId = f.PostId,
                PetName = f.Post?.Pet?.Name ?? "Unknown",
                PetImageUrl = f.Post?.Pet?.ImageUrl ?? string.Empty,
                FavouritedAt = f.CreatedAt,
                PostTitle = f.Post?.Title ?? string.Empty,
                PostContent = f.Post?.Content ?? string.Empty
            });
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                TotalFavourites = response.Count(),
                Favourites = response
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

// Request DTOs
public class AddFavouriteRequest
{
    public string UserId { get; set; } = string.Empty;
    public string PostId { get; set; } = string.Empty;
}