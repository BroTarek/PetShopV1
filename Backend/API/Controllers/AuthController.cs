using Microsoft.AspNetCore.Mvc;
using PetShop.BackendV2.Application.Services;
using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
    {
        try
        {
            var user = await _authService.CreateUserAsync(request);
            
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


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var user = await _authService.AuthenticateAsync(request.Email, request.Password);
            
            var token = _authService.GenerateJwtToken(user);
            
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



    [HttpPut("{userId}/change-password")]
    public async Task<IActionResult> ChangePassword(string userId, [FromBody] ChangePasswordRequest request)
    {
        try
        {
            await _authService.ChangeUserPasswordAsync(userId, request);
            
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





    [HttpGet("check-email")]
    public async Task<IActionResult> CheckEmailExists([FromQuery] string email)
    {
        try
        {
            var exists = await _authService.EmailExistsAsync(email);
            
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


}
