using Microsoft.AspNetCore.Mvc;
using PetShop.BackendV2.Application.Services;
using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly PostService _postService;

    public PostController(PostService postService)
    {
        _postService = postService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
    {
        try
        {
            var post = await _postService.CreatePostAsync(request);
            
            return Ok(new
            {
                Success = true,
                Message = "Post created successfully",
                PostId = post.Id,
                CreationDate = post.CreationDate
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
        catch (InvalidOperationException ex)
        {
            return Conflict(new { Success = false, Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpPut("update/{postId}")]
    public async Task<IActionResult> UpdatePost(string postId, [FromBody] UpdatePostRequest request)
    {
        try
        {
            var post = await _postService.UpdatePostAsync(postId, request);
            
            return Ok(new
            {
                Success = true,
                Message = "Post updated successfully",
                PostId = post.Id,
                LastModified = post.LastModified
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

    [HttpDelete("delete/{postId}")]
    public async Task<IActionResult> DeletePost(string postId, [FromQuery] string userId)
    {
        try
        {
            await _postService.DeletePostAsync(postId, userId);
            
            return Ok(new
            {
                Success = true,
                Message = "Post deleted successfully"
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

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetPostById(string postId)
    {
        try
        {
            var post = await _postService.GetPostByIdAsync(postId);
            
            var response = new PostResponseVM
            {
                PostId = post.Id,
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                PetId = post.PetId,
                PetName = post.Pet?.Name ?? "Unknown",
                PetImageUrl = post.Pet?.ImageUrl ?? string.Empty,
                PetBreed = post.Pet?.Breed ?? string.Empty,
                UserId = post.UserId,
                UserName = $"{post.User?.FirstName} {post.User?.LastName}",
                UserEmail = post.User?.Email ?? string.Empty,
                CreationDate = post.CreationDate,
                LastModified = post.LastModified,
                IsActive = post.IsActive,
                FavouriteCount = post.Favourites?.Count ?? 0
            };
            
            return Ok(new { Success = true, Post = response });
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

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetPostsByUserId(string userId)
    {
        try
        {
            var posts = await _postService.GetPostsByUserIdAsync(userId);
            
            var response = posts.Select(post => new PostResponseVM
            {
                PostId = post.Id,
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                PetId = post.PetId,
                PetName = post.Pet?.Name ?? "Unknown",
                PetImageUrl = post.Pet?.ImageUrl ?? string.Empty,
                UserId = post.UserId,
                UserName = $"{post.User?.FirstName} {post.User?.LastName}",
                CreationDate = post.CreationDate,
                LastModified = post.LastModified,
                IsActive = post.IsActive,
                FavouriteCount = post.Favourites?.Count ?? 0
            });
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                TotalPosts = response.Count(),
                Posts = response
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

    [HttpGet("pet/{petId}")]
    public async Task<IActionResult> GetPostsByPetId(string petId)
    {
        try
        {
            var posts = await _postService.GetPostsByPetIdAsync(petId);
            
            var response = posts.Select(post => new PostResponseVM
            {
                PostId = post.Id,
                Title = post.Title,
                Description = post.Description,
                PetId = post.PetId,
                PetName = post.Pet?.Name ?? "Unknown",
                UserId = post.UserId,
                UserName = $"{post.User?.FirstName} {post.User?.LastName}",
                CreationDate = post.CreationDate,
                FavouriteCount = post.Favourites?.Count ?? 0
            });
            
            return Ok(new
            {
                Success = true,
                PetId = petId,
                TotalPosts = response.Count(),
                Posts = response
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

    [HttpGet("all")]
    public async Task<IActionResult> GetAllPosts()
    {
        try
        {
            var posts = await _postService.GetAllPostsAsync();
            
            var response = posts.Select(post => new PostResponseVM
            {
                PostId = post.Id,
                Title = post.Title,
                Description = post.Description,
                PetId = post.PetId,
                PetName = post.Pet?.Name ?? "Unknown",
                PetImageUrl = post.Pet?.ImageUrl ?? string.Empty,
                UserId = post.UserId,
                UserName = $"{post.User?.FirstName} {post.User?.LastName}",
                CreationDate = post.CreationDate,
                FavouriteCount = post.Favourites?.Count ?? 0
            });
            
            return Ok(new
            {
                Success = true,
                TotalPosts = response.Count(),
                Posts = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActivePosts()
    {
        try
        {
            var posts = await _postService.GetActivePostsAsync();
            
            var response = posts.Select(post => new PostResponseVM
            {
                PostId = post.Id,
                Title = post.Title,
                Description = post.Description,
                PetId = post.PetId,
                PetName = post.Pet?.Name ?? "Unknown",
                UserId = post.UserId,
                UserName = $"{post.User?.FirstName} {post.User?.LastName}",
                CreationDate = post.CreationDate
            });
            
            return Ok(new
            {
                Success = true,
                TotalActivePosts = response.Count(),
                Posts = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("user/{userId}/count")]
    public async Task<IActionResult> GetUserPostCount(string userId)
    {
        try
        {
            var count = await _postService.GetPostCountByUserAsync(userId);
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                PostCount = count
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("check-ownership")]
    public async Task<IActionResult> CheckOwnership([FromQuery] string userId, [FromQuery] string postId)
    {
        try
        {
            var ownsPost = await _postService.UserOwnsPostAsync(userId, postId);
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                PostId = postId,
                OwnsPost = ownsPost
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }
}