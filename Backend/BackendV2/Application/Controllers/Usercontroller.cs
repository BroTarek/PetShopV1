using Microsoft.AspNetCore.Mvc;
using PetShop.BackendV2.Application.Services;
using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    #region Authentication

    /// <summary>
    /// Register a new user
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
    {
        try
        {
            var user = await _userService.CreateUserAsync(request);
            
            return Ok(new
            {
                Success = true,
                Message = "User registered successfully. Please wait for admin approval.",
                UserId = user.Id,
                Email = user.Email,
                Status = user.AccountStatus.ToString()
            });
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
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Login user
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var user = await _userService.AuthenticateAsync(request.Email, request.Password);
            
            // TODO: Generate JWT token here
            var token = GenerateJwtToken(user); // Implement this method
            
            var response = new LoginResponseVM
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.ToString(),
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
            
            return Ok(new
            {
                Success = true,
                Message = "Login successful",
                Data = response
            });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    #endregion

    #region User Management

    /// <summary>
    /// Get user by ID
    /// </summary>
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(string userId)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(userId);
            
            var response = new UserResponseVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.ToString(),
                AccountStatus = user.AccountStatus.ToString(),
                CreatedAt = user.CreatedAt
            };
            
            return Ok(new { Success = true, User = response });
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

    /// <summary>
    /// Get user profile with statistics
    /// </summary>
    [HttpGet("{userId}/profile")]
    public async Task<IActionResult> GetUserProfile(string userId)
    {
        try
        {
            var profile = await _userService.GetUserProfileAsync(userId);
            return Ok(new { Success = true, Profile = profile });
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

    /// <summary>
    /// Update user profile
    /// </summary>
    [HttpPut("{userId}/profile")]
    public async Task<IActionResult> UpdateUserProfile(string userId, [FromBody] UpdateUserProfileRequest request)
    {
        try
        {
            var user = await _userService.UpdateUserProfileAsync(userId, request);
            
            return Ok(new
            {
                Success = true,
                Message = "Profile updated successfully",
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
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

    /// <summary>
    /// Change user password
    /// </summary>
    [HttpPut("{userId}/change-password")]
    public async Task<IActionResult> ChangePassword(string userId, [FromBody] ChangePasswordRequest request)
    {
        try
        {
            await _userService.ChangeUserPasswordAsync(userId, request);
            
            return Ok(new
            {
                Success = true,
                Message = "Password changed successfully"
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
        catch (ArgumentException ex)
        {
            return BadRequest(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Delete user account
    /// </summary>
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        try
        {
            await _userService.DeleteUserAsync(userId);
            
            return Ok(new
            {
                Success = true,
                Message = "User account deleted successfully"
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

    #region Admin Operations

    /// <summary>
    /// Get all users (Admin only)
    /// </summary>
    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            
            var response = users.Select(user => new UserResponseVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.ToString(),
                AccountStatus = user.AccountStatus.ToString(),
                CreatedAt = user.CreatedAt
            });
            
            return Ok(new
            {
                Success = true,
                TotalUsers = response.Count(),
                Users = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Get users by role
    /// </summary>
    [HttpGet("role/{role}")]
    public async Task<IActionResult> GetUsersByRole(string role)
    {
        try
        {
            if (!Enum.TryParse<Role>(role, true, out var userRole))
                return BadRequest(new { Success = false, Error = "Invalid role" });
            
            var users = await _userService.GetUsersByRoleAsync(userRole);
            
            var response = users.Select(user => new UserResponseVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.ToString(),
                AccountStatus = user.AccountStatus.ToString(),
                CreatedAt = user.CreatedAt
            });
            
            return Ok(new
            {
                Success = true,
                Role = role,
                TotalUsers = response.Count(),
                Users = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Get all pending users (Admin only)
    /// </summary>
    [HttpGet("pending")]
    public async Task<IActionResult> GetAllPendingUsers()
    {
        try
        {
            var users = await _userService.GetAllPendingUsersAsync();
            
            var response = users.Select(user => new UserResponseVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.ToString(),
                AccountStatus = user.AccountStatus.ToString(),
                CreatedAt = user.CreatedAt
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
    /// Activate user account (Admin only)
    /// </summary>
    [HttpPut("{userId}/activate")]
    public async Task<IActionResult> ActivateUser(string userId)
    {
        try
        {
            var user = await _userService.ActivateUserAsync(userId);
            
            return Ok(new
            {
                Success = true,
                Message = "User account activated successfully",
                UserId = user.Id,
                Status = user.AccountStatus.ToString()
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

    /// <summary>
    /// Deactivate user account (Admin only)
    /// </summary>
    [HttpPut("{userId}/deactivate")]
    public async Task<IActionResult> DeactivateUser(string userId)
    {
        try
        {
            var user = await _userService.DeactivateUserAsync(userId);
            
            return Ok(new
            {
                Success = true,
                Message = "User account deactivated successfully",
                UserId = user.Id,
                Status = user.AccountStatus.ToString()
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

    #region Statistics

    /// <summary>
    /// Get total user count
    /// </summary>
    [HttpGet("count")]
    public async Task<IActionResult> GetUserCount()
    {
        try
        {
            var count = await _userService.GetUserCountAsync();
            
            return Ok(new
            {
                Success = true,
                TotalUsers = count
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// Check if email exists
    /// </summary>
    [HttpGet("check-email")]
    public async Task<IActionResult> CheckEmailExists([FromQuery] string email)
    {
        try
        {
            var exists = await _userService.EmailExistsAsync(email);
            
            return Ok(new
            {
                Success = true,
                Email = email,
                Exists = exists
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = ex.Message });
        }
    }

    #endregion

    #region Private Helpers

    private string GenerateJwtToken(User user)
    {
        // TODO: Implement JWT token generation
        // This is a placeholder
        return "sample-jwt-token";
    }

    #endregion
}

// Login Request DTO
public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}