using Microsoft.AspNetCore.Mvc;
using PetShop.BackendV2.Application.Services;
using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly PetService _petService;

    public PetController(PetService petService)
    {
        _petService = petService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePet([FromForm] CreatePetRequest request, [FromForm] List<IFormFile> images)
    {
        try
        {
            var pet = await _petService.CreatePetAsync(request, images);
            
            return Ok(new
            {
                Success = true,
                Message = "Pet created successfully",
                PetId = pet.Id,
                ImageCount = pet.Images.Count
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Success = false, Error = ex.Message });
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

    [HttpPut("update/{petId}")]
    public async Task<IActionResult> UpdatePet(string petId, [FromForm] UpdatePetRequest request, [FromForm] List<IFormFile>? images = null)
    {
        try
        {
            var pet = await _petService.UpdatePetAsync(petId, request, images);
            
            return Ok(new
            {
                Success = true,
                Message = "Pet updated successfully",
                PetId = pet.Id,
                LastModified = pet.LastModified
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
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpDelete("delete/{petId}")]
    public async Task<IActionResult> DeletePet(string petId, [FromQuery] string ownerId)
    {
        try
        {
            await _petService.DeletePetAsync(petId, ownerId);
            
            return Ok(new
            {
                Success = true,
                Message = "Pet deleted successfully"
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

    [HttpGet("{petId}")]
    public async Task<IActionResult> GetPetById(string petId)
    {
        try
        {
            var pet = await _petService.GetPetByIdAsync(petId);
            
            var response = new PetResponseVM
            {
                PetId = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Age = pet.Age,
                Gender = pet.Gender.ToString(),
                Location = pet.Location,
                HealthStatus = pet.HealthStatus.ToString(),
                Description = pet.Description,
                Images = pet.Images,
                Status = pet.Status.ToString(),
                OwnerId = pet.OwnerId,
                OwnerName = $"{pet.Owner?.FirstName} {pet.Owner?.LastName}",
                OwnerEmail = pet.Owner?.Email ?? string.Empty,
                CreationDate = pet.CreationDate,
                LastModified = pet.LastModified,
                ActiveAdoptionRequests = pet.AdoptionRequests?.Count(ar => ar.Status == AdoptionStatus.Pending) ?? 0,
                HasActivePost = pet.Post != null && pet.Post.IsActive
            };
            
            return Ok(new { Success = true, Pet = response });
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
    public async Task<IActionResult> GetAllPets()
    {
        try
        {
            var pets = await _petService.GetAllPetsAsync();
            
            var response = pets.Select(pet => new PetListResponseVM
            {
                PetId = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Age = pet.Age,
                Location = pet.Location,
                PrimaryImage = pet.Images.FirstOrDefault() ?? string.Empty,
                Status = pet.Status.ToString(),
                OwnerName = $"{pet.Owner?.FirstName} {pet.Owner?.LastName}"
            });
            
            return Ok(new
            {
                Success = true,
                TotalPets = response.Count(),
                Pets = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("owner/{ownerId}")]
    public async Task<IActionResult> GetPetsByOwner(string ownerId)
    {
        try
        {
            var pets = await _petService.GetPetsByOwnerIdAsync(ownerId);
            
            var response = pets.Select(pet => new PetListResponseVM
            {
                PetId = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Age = pet.Age,
                Location = pet.Location,
                PrimaryImage = pet.Images.FirstOrDefault() ?? string.Empty,
                Status = pet.Status.ToString(),
                OwnerName = $"{pet.Owner?.FirstName} {pet.Owner?.LastName}"
            });
            
            return Ok(new
            {
                Success = true,
                OwnerId = ownerId,
                TotalPets = response.Count(),
                Pets = response
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

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailablePets()
    {
        try
        {
            var pets = await _petService.GetAvailablePetsAsync();
            
            var response = pets.Select(pet => new PetListResponseVM
            {
                PetId = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Age = pet.Age,
                Location = pet.Location,
                PrimaryImage = pet.Images.FirstOrDefault() ?? string.Empty,
                Status = pet.Status.ToString(),
                OwnerName = $"{pet.Owner?.FirstName} {pet.Owner?.LastName}"
            });
            
            return Ok(new
            {
                Success = true,
                TotalAvailable = response.Count(),
                Pets = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchPets([FromBody] PetSearchRequest searchRequest)
    {
        try
        {
            var pets = await _petService.SearchPetsAsync(searchRequest);
            
            var response = pets.Select(pet => new PetListResponseVM
            {
                PetId = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Age = pet.Age,
                Location = pet.Location,
                PrimaryImage = pet.Images.FirstOrDefault() ?? string.Empty,
                Status = pet.Status.ToString(),
                OwnerName = $"{pet.Owner?.FirstName} {pet.Owner?.LastName}"
            });
            
            return Ok(new
            {
                Success = true,
                SearchCriteria = searchRequest,
                TotalResults = response.Count(),
                Pets = response
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("type/{type}")]
    public async Task<IActionResult> FindByType(string type)
    {
        try
        {
            var pets = await _petService.FindByTypeAsync(type);
            
            return Ok(new
            {
                Success = true,
                Type = type,
                Count = pets.Count,
                Pets = pets.Select(p => new { p.Id, p.Name, p.Breed, p.Age })
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("breed/{breed}")]
    public async Task<IActionResult> FindByBreed(string breed)
    {
        try
        {
            var pets = await _petService.FindByBreedAsync(breed);
            
            return Ok(new
            {
                Success = true,
                Breed = breed,
                Count = pets.Count,
                Pets = pets.Select(p => new { p.Id, p.Name, p.Type, p.Age })
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("location/{location}")]
    public async Task<IActionResult> FindByLocation(string location)
    {
        try
        {
            var pets = await _petService.FindByLocationAsync(location);
            
            return Ok(new
            {
                Success = true,
                Location = location,
                Count = pets.Count,
                Pets = pets.Select(p => new { p.Id, p.Name, p.Breed, p.Location })
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("age-range")]
    public async Task<IActionResult> FindByAgeRange([FromQuery] int minAge, [FromQuery] int maxAge)
    {
        try
        {
            var pets = await _petService.FindByAgeRangeAsync(minAge, maxAge);
            
            return Ok(new
            {
                Success = true,
                AgeRange = $"{minAge}-{maxAge} years",
                Count = pets.Count,
                Pets = pets.Select(p => new { p.Id, p.Name, p.Age, p.Breed })
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("check-ownership")]
    public async Task<IActionResult> CheckOwnership([FromQuery] string userId, [FromQuery] string petId)
    {
        try
        {
            var ownsPet = await _petService.UserOwnsPetAsync(userId, petId);
            
            return Ok(new
            {
                Success = true,
                UserId = userId,
                PetId = petId,
                OwnsPet = ownsPet
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }

    [HttpGet("owner/{ownerId}/count")]
    public async Task<IActionResult> GetPetCountByOwner(string ownerId)
    {
        try
        {
            var count = await _petService.GetPetCountByOwnerAsync(ownerId);
            
            return Ok(new
            {
                Success = true,
                OwnerId = ownerId,
                PetCount = count
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Success = false, Error = "An error occurred" });
        }
    }
}