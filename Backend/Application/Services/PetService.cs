using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace PetShop.BackendV2.Application.Services;

public class PetService
{
    private readonly IPetRepository _petRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;

    public PetService(
        IPetRepository petRepository,
        IUserRepository userRepository,
        IFileService fileService)
    {
        _petRepository = petRepository;
        _userRepository = userRepository;
        _fileService = fileService;
    }

    public async Task<Pet> CreatePetAsync(CreatePetRequest request, List<IFormFile> images)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(request.OwnerId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {request.OwnerId} not found");

        // Validate image count
        if (images == null || !images.Any())
            throw new ArgumentException("At least one image is required");

        if (images.Count > 10)
            throw new ArgumentException("Maximum 10 images allowed per pet");

        // Upload images
        var imageUrls = new List<string>();
        foreach (var image in images)
        {
            // Validate image type
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(image.FileName).ToLower();
            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException($"Invalid image format. Allowed: {string.Join(", ", allowedExtensions)}");

            // Validate image size (max 5MB)
            if (image.Length > 5 * 1024 * 1024)
                throw new ArgumentException($"Image {image.FileName} exceeds 5MB limit");

            using var stream = image.OpenReadStream();
            var imageUrl = await _fileService.UploadFileAsync(stream, image.FileName, "pets");
            imageUrls.Add(imageUrl);
        }

        // Create pet
        var pet = new Pet
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Type = request.Type,
            Breed = request.Breed,
            Age = request.Age,
            Gender = request.Gender,
            Location = request.Location,
            HealthStatus = request.HealthStatus,
            Description = request.Description,
            Images = imageUrls,
            Status = PetStatus.Available,
            OwnerId = request.OwnerId,
            Owner = user,
            CreationDate = DateTime.UtcNow,
            LastModified = DateTime.UtcNow
        };

        return await _petRepository.CreateAsync(pet);
    }

    public async Task<Pet> UpdatePetAsync(string petId, UpdatePetRequest request, List<IFormFile>? newImages = null)
    {
        // Validate pet exists
        var pet = await _petRepository.GetByIdAsync(petId);
        if (pet == null)
            throw new KeyNotFoundException($"Pet with ID {petId} not found");

        // Verify ownership
        if (pet.OwnerId != request.OwnerId)
            throw new UnauthorizedAccessException("You can only update your own pets");

        // Update basic information
        pet.Name = request.Name ?? pet.Name;
        pet.Type = request.Type ?? pet.Type;
        pet.Breed = request.Breed ?? pet.Breed;
        pet.Age = request.Age ?? pet.Age;
        pet.Gender = request.Gender ?? pet.Gender;
        pet.Location = request.Location ?? pet.Location;
        pet.HealthStatus = request.HealthStatus ?? pet.HealthStatus;
        pet.Description = request.Description ?? pet.Description;
        pet.Status = request.Status ?? pet.Status;
        pet.LastModified = DateTime.UtcNow;

        // Handle image updates if new images provided
        if (newImages != null && newImages.Any())
        {
            // Delete old images
            foreach (var oldImage in pet.Images)
            {
                await _fileService.DeleteFileAsync(oldImage);
            }

            // Upload new images
            var newImageUrls = new List<string>();
            foreach (var image in newImages.Take(10)) // Max 10 images
            {
                using var stream = image.OpenReadStream();
                var imageUrl = await _fileService.UploadFileAsync(stream, image.FileName, "pets");
                newImageUrls.Add(imageUrl);
            }
            pet.Images = newImageUrls;
        }

        await _petRepository.UpdateAsync(pet);
        return pet;
    }

    public async Task DeletePetAsync(string petId, string ownerId)
    {
        // Validate pet exists
        var pet = await _petRepository.GetByIdAsync(petId);
        if (pet == null)
            throw new KeyNotFoundException($"Pet with ID {petId} not found");

        // Verify ownership
        if (pet.OwnerId != ownerId)
            throw new UnauthorizedAccessException("You can only delete your own pets");

        // Check if pet has active adoption requests
        if (pet.AdoptionRequests != null && pet.AdoptionRequests.Any(ar => ar.Status == AdoptionStatus.Pending))
            throw new InvalidOperationException("Cannot delete pet with pending adoption requests");

        // Delete associated images
        foreach (var image in pet.Images)
        {
            await _fileService.DeleteFileAsync(image);
        }

        await _petRepository.DeleteAsync(petId);
    }

    public async Task<Pet> GetPetByIdAsync(string petId)
    {
        var pet = await _petRepository.GetByIdAsync(petId);
        if (pet == null)
            throw new KeyNotFoundException($"Pet with ID {petId} not found");

        return pet;
    }

    public async Task<List<Pet>> GetAllPetsAsync()
    {
        return await _petRepository.GetAllPetsAsync();
    }

    public async Task<List<Pet>> GetPetsByOwnerIdAsync(string ownerId)
    {
        // Validate user exists
        var user = await _userRepository.GetByIdAsync(ownerId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {ownerId} not found");

        return await _petRepository.GetPetsByOwnerIdAsync(ownerId);
    }

    public async Task<List<Pet>> GetAvailablePetsAsync()
    {
        return await _petRepository.GetAvailablePetsAsync();
    }

    public async Task<List<Pet>> GetAdoptedPetsAsync()
    {
        return await _petRepository.GetAdoptedPetsAsync();
    }

    public async Task<List<Pet>> SearchPetsAsync(PetSearchRequest searchRequest)
    {
        var criteria = new PetSearchCriteria
        {
            Type = searchRequest.Type,
            Breed = searchRequest.Breed,
            Location = searchRequest.Location,
            MinAge = searchRequest.MinAge,
            MaxAge = searchRequest.MaxAge,
            Gender = searchRequest.Gender,
            HealthStatus = searchRequest.HealthStatus,
            Status = searchRequest.Status ?? PetStatus.Available
        };

        return await _petRepository.FindByCriteriaAsync(criteria);
    }

    public async Task<List<Pet>> FindByTypeAsync(string type)
    {
        return await _petRepository.FindByTypeAsync(type);
    }

    public async Task<List<Pet>> FindByBreedAsync(string breed)
    {
        return await _petRepository.FindByBreedAsync(breed);
    }

    public async Task<List<Pet>> FindByLocationAsync(string location)
    {
        return await _petRepository.FindByLocationAsync(location);
    }

    public async Task<List<Pet>> FindByAgeRangeAsync(int minAge, int maxAge)
    {
        return await _petRepository.FindByAgeRangeAsync(minAge, maxAge);
    }

    public async Task<bool> UserOwnsPetAsync(string userId, string petId)
    {
        return await _petRepository.UserOwnsPetAsync(userId, petId);
    }

    public async Task<int> GetPetCountByOwnerAsync(string ownerId)
    {
        return await _petRepository.GetPetCountByOwnerAsync(ownerId);
    }
}

// Request DTOs
public class CreatePetRequest
{
    public string OwnerId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string Location { get; set; } = string.Empty;
    public HealthStatus HealthStatus { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class UpdatePetRequest
{
    public string OwnerId { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Breed { get; set; }
    public int? Age { get; set; }
    public Gender? Gender { get; set; }
    public string? Location { get; set; }
    public HealthStatus? HealthStatus { get; set; }
    public string? Description { get; set; }
    public PetStatus? Status { get; set; }
}

public class PetSearchRequest
{
    public string? Type { get; set; }
    public string? Breed { get; set; }
    public string? Location { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public Gender? Gender { get; set; }
    public HealthStatus? HealthStatus { get; set; }
    public PetStatus? Status { get; set; }
}
