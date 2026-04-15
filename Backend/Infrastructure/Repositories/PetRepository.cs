using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Infrastructure.Data;

namespace PetShop.BackendV2.Infrastructure.Repositories;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pet> CreateAsync(Pet pet)
    {
        pet.CreationDate = DateTime.UtcNow;
        pet.LastModified = DateTime.UtcNow;
        await _context.Pets.AddAsync(pet);
        return pet;
    }

    public async Task<Pet?> GetByIdAsync(string id)
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Include(p => p.AdoptionRequests)
            .Include(p => p.Post)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Pet pet)
    {
        pet.LastModified = DateTime.UtcNow;
        _context.Pets.Update(pet);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(string id)
    {
        var pet = await GetByIdAsync(id);
        if (pet != null)
        {
            _context.Pets.Remove(pet);
        }
    }

    public async Task<List<Pet>> GetAllPetsAsync()
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Include(p => p.AdoptionRequests)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<List<Pet>> GetPetsByOwnerIdAsync(string ownerId)
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Include(p => p.AdoptionRequests)
            .Where(p => p.OwnerId == ownerId)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<List<Pet>> GetPetsByStatusAsync(PetStatus status)
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.Status == status)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<List<Pet>> GetAvailablePetsAsync()
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.Status == PetStatus.Available)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<List<Pet>> GetAdoptedPetsAsync()
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.Status == PetStatus.Adopted)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<List<Pet>> FindByTypeAsync(string type)
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.Type.ToLower().Contains(type.ToLower()))
            .ToListAsync();
    }

    public async Task<List<Pet>> FindByBreedAsync(string breed)
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.Breed.ToLower().Contains(breed.ToLower()))
            .ToListAsync();
    }

    public async Task<List<Pet>> FindByLocationAsync(string location)
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.Location.ToLower().Contains(location.ToLower()))
            .ToListAsync();
    }

    public async Task<List<Pet>> FindByAgeRangeAsync(int minAge, int maxAge)
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.Age >= minAge && p.Age <= maxAge)
            .ToListAsync();
    }

    public async Task<List<Pet>> FindByHealthStatusAsync(HealthStatus healthStatus)
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.HealthStatus == healthStatus)
            .ToListAsync();
    }

    public async Task<List<Pet>> SearchPetsAsync(string searchTerm)
    {
        searchTerm = searchTerm.ToLower();
        return await _context.Pets
            .Include(p => p.Owner)
            .Where(p => p.Name.ToLower().Contains(searchTerm) ||
                        p.Type.ToLower().Contains(searchTerm) ||
                        p.Breed.ToLower().Contains(searchTerm) ||
                        p.Location.ToLower().Contains(searchTerm) ||
                        p.Description.ToLower().Contains(searchTerm))
            .ToListAsync();
    }

    public async Task<List<Pet>> FindByCriteriaAsync(PetSearchCriteria criteria)
    {
        var query = _context.Pets.Include(p => p.Owner).AsQueryable();

        if (!string.IsNullOrEmpty(criteria.Type))
            query = query.Where(p => p.Type.ToLower().Contains(criteria.Type.ToLower()));

        if (!string.IsNullOrEmpty(criteria.Breed))
            query = query.Where(p => p.Breed.ToLower().Contains(criteria.Breed.ToLower()));

        if (!string.IsNullOrEmpty(criteria.Location))
            query = query.Where(p => p.Location.ToLower().Contains(criteria.Location.ToLower()));

        if (criteria.MinAge.HasValue)
            query = query.Where(p => p.Age >= criteria.MinAge.Value);

        if (criteria.MaxAge.HasValue)
            query = query.Where(p => p.Age <= criteria.MaxAge.Value);

        if (criteria.Gender.HasValue)
            query = query.Where(p => p.Gender == criteria.Gender.Value);

        if (criteria.HealthStatus.HasValue)
            query = query.Where(p => p.HealthStatus == criteria.HealthStatus.Value);

        if (criteria.Status.HasValue)
            query = query.Where(p => p.Status == criteria.Status.Value);

        return await query.OrderByDescending(p => p.CreationDate).ToListAsync();
    }

    public async Task<bool> ExistsAsync(string petId)
    {
        return await _context.Pets.AnyAsync(p => p.Id == petId);
    }

    public async Task<bool> UserOwnsPetAsync(string userId, string petId)
    {
        return await _context.Pets.AnyAsync(p => p.Id == petId && p.OwnerId == userId);
    }

    public async Task<int> GetPetCountByOwnerAsync(string ownerId)
    {
        return await _context.Pets.CountAsync(p => p.OwnerId == ownerId);
    }

    public async Task<int> GetPetCountByStatusAsync(PetStatus status)
    {
        return await _context.Pets.CountAsync(p => p.Status == status);
    }
}