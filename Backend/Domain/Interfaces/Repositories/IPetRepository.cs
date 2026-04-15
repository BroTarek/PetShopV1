using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Domain.Interfaces.Repositories;

public interface IPetRepository
{
    // CRUD Operations
    Task<Pet> CreateAsync(Pet pet);
    Task<Pet?> GetByIdAsync(string id);
    Task UpdateAsync(Pet pet);
    Task DeleteAsync(string id);
    
    // Query Methods
    Task<List<Pet>> GetAllPetsAsync();
    Task<List<Pet>> GetPetsByOwnerIdAsync(string ownerId);
    Task<List<Pet>> GetPetsByStatusAsync(PetStatus status);
    Task<List<Pet>> GetAvailablePetsAsync();
    Task<List<Pet>> GetAdoptedPetsAsync();
    
    // Search/Filter Methods
    Task<List<Pet>> FindByTypeAsync(string type);
    Task<List<Pet>> FindByBreedAsync(string breed);
    Task<List<Pet>> FindByLocationAsync(string location);
    Task<List<Pet>> FindByAgeRangeAsync(int minAge, int maxAge);
    Task<List<Pet>> FindByHealthStatusAsync(HealthStatus healthStatus);
    Task<List<Pet>> SearchPetsAsync(string searchTerm);
    
    // Advanced Search with multiple criteria
    Task<List<Pet>> FindByCriteriaAsync(PetSearchCriteria criteria);
    
    // Validation
    Task<bool> ExistsAsync(string petId);
    Task<bool> UserOwnsPetAsync(string userId, string petId);
    
    // Statistics
    Task<int> GetPetCountByOwnerAsync(string ownerId);
    Task<int> GetPetCountByStatusAsync(PetStatus status);
}
