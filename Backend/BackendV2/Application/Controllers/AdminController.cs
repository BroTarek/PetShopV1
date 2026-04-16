using Microsoft.AspNetCore.Mvc;
using PetShop.BackendV2.Application.Services;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.API.Controllers;


[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly AdminService _adminService;

    public AdminController(AdminService adminService)
    {
        _adminService = adminService;
    }

    #region User Management

    /// <summary>
    /// Get all pending users (awaiting approval)
    /// </summary>
    [HttpGet("users/pending")]
    public async Task<IActionResult> GetAllPendingUsers()
    {
        try
        {
            var users = await _adminService.GetAllPendingUsers();
            
            var response = users.Select(user => new UserAdminResponseVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.ToString(),
                AccountStatus = user.AccountStatus.ToString(),
                CreatedAt = user.CreatedAt,
                TotalPets = user.Pets?.Count ?? 0,
                TotalPosts = user.Posts?.Count ?? 0
            });
            
            return Ok(new
            {
                Success = true,
                TotalPending = response.Count(),
                Users = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Approve a user account
    /// </summary>
    [HttpPut("users/{userId}/approve")]
    public async Task<IActionResult> ApproveUser(string userId)
    {
        try
        {
            var user = await _adminService.ApproveUserCreation(userId);
            
            return Ok(new
            {
                Success = true,
                Message = "User account approved successfully",
                UserId = user.Id,
                Email = user.Email,
                Status = user.AccountStatus.ToString()
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
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Reject a user account
    /// </summary>
    [HttpPut("users/{userId}/reject")]
    public async Task<IActionResult> RejectUser(string userId)
    {
        try
        {
            var user = await _adminService.RejectUserCreation(userId);
            
            return Ok(new
            {
                Success = true,
                Message = "User account rejected successfully",
                UserId = user.Id,
                Email = user.Email,
                Status = user.AccountStatus.ToString()
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
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Delete a user account (admin only)
    /// </summary>
    [HttpDelete("users/{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        try
        {
            await _adminService.DeleteUserAsync(userId);
            
            return Ok(new
            {
                Success = true,
                Message = "User account deleted successfully",
                UserId = userId
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
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Get user by email
    /// </summary>
    [HttpGet("users/email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        try
        {
            var user = await _adminService.GetByEmailAsync(email);
            
            if (user == null)
                return NotFound(new { Success = false, Error = $"User with email {email} not found" });
            
            var response = new UserAdminResponseVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.ToString(),
                AccountStatus = user.AccountStatus.ToString(),
                CreatedAt = user.CreatedAt,
                TotalPets = user.Pets?.Count ?? 0,
                TotalPosts = user.Posts?.Count ?? 0,
                TotalReviewsGiven = user.ReviewsMade?.Count ?? 0,
                TotalReviewsReceived = user.ReviewsReceived?.Count ?? 0
            };
            
            return Ok(new { Success = true, User = response });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    #endregion

    #region Post Management

    /// <summary>
    /// Get all pending posts (awaiting approval)
    /// </summary>
    [HttpGet("posts/pending")]
    public async Task<IActionResult> GetAllPendingPosts()
    {
        try
        {
            var posts = await _adminService.GetAllPendingPosts();
            
            var response = posts.Select(post => new PostAdminResponseVM
            {
                PostId = post.Id,
                Title = post.Title,
                Description = post.Description,
                PetName = post.Pet?.Name ?? "Unknown",
                PetType = post.Pet?.Type ?? "Unknown",
                OwnerName = $"{post.User?.FirstName} {post.User?.LastName}",
                OwnerEmail = post.User?.Email ?? string.Empty,
                CreationDate = post.CreationDate,
                Status = post.Status?.ToString() ?? "Pending",
                IsActive = post.IsActive
            });
            
            return Ok(new
            {
                Success = true,
                TotalPending = response.Count(),
                Posts = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Approve a post
    /// </summary>
    [HttpPut("posts/{postId}/approve")]
    public async Task<IActionResult> ApprovePost(string postId)
    {
        try
        {
            var post = await _adminService.ApprovePostCreation(postId);
            
            return Ok(new
            {
                Success = true,
                Message = "Post approved successfully",
                PostId = post.Id,
                Title = post.Title,
                Status = post.Status?.ToString() ?? "Approved"
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
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Reject a post
    /// </summary>
    [HttpPut("posts/{postId}/reject")]
    public async Task<IActionResult> RejectPost(string postId)
    {
        try
        {
            var post = await _adminService.RejectPostCreation(postId);
            
            return Ok(new
            {
                Success = true,
                Message = "Post rejected successfully",
                PostId = post.Id,
                Title = post.Title,
                Status = post.Status?.ToString() ?? "Rejected"
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
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Delete a post (admin only)
    /// </summary>
    [HttpDelete("posts/{postId}")]
    public async Task<IActionResult> DeletePost(string postId)
    {
        try
        {
            await _adminService.DeletePostAsync(postId);
            
            return Ok(new
            {
                Success = true,
                Message = "Post deleted successfully",
                PostId = postId
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    #endregion

    #region Dashboard Statistics

    /// <summary>
    /// Get admin dashboard statistics
    /// </summary>
    [HttpGet("dashboard/stats")]
    public async Task<IActionResult> GetDashboardStats()
    {
        try
        {
            var stats = await _adminService.GetDashboardStatisticsAsync();
            
            return Ok(new
            {
                Success = true,
                Statistics = stats
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    #endregion
}