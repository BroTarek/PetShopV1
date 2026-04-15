using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Infrastructure.Data;

namespace PetShop.BackendV2.Infrastructure.Repositories;

public class AdoptionRequestRepository : IAdoptionRequestRepository
{
    private readonly AppDbContext _context;

    public AdoptionRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AdoptionRequest> CreateAsync(AdoptionRequest request)
    {
        await _context.AdoptionRequests.AddAsync(request);
        return request;
    }

    public async Task<AdoptionRequest?> GetByIdAsync(string id)
    {
        return await _context.AdoptionRequests
            .Include(ar => ar.Pet)
            .Include(ar => ar.Initiator)
            .Include(ar => ar.Receiver)
            .FirstOrDefaultAsync(ar => ar.Id == id);
    }

    public async Task UpdateAsync(AdoptionRequest request)
    {
        _context.AdoptionRequests.Update(request);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(string id)
    {
        var request = await GetByIdAsync(id);
        if (request != null)
        {
            _context.AdoptionRequests.Remove(request);
        }
    }

    public async Task<List<AdoptionRequest>> GetByInitiatorIdAsync(string initiatorId)
    {
        return await _context.AdoptionRequests
            .Include(ar => ar.Pet)
            .Include(ar => ar.Receiver)
            .Where(ar => ar.InitiatorId == initiatorId)
            .OrderByDescending(ar => ar.RequestDate)
            .ToListAsync();
    }

    public async Task<List<AdoptionRequest>> GetByReceiverIdAsync(string receiverId)
    {
        return await _context.AdoptionRequests
            .Include(ar => ar.Pet)
            .Include(ar => ar.Initiator)
            .Where(ar => ar.ReceiverId == receiverId)
            .OrderByDescending(ar => ar.RequestDate)
            .ToListAsync();
    }

    public async Task<List<AdoptionRequest>> GetByPetIdAsync(string petId)
    {
        return await _context.AdoptionRequests
            .Include(ar => ar.Initiator)
            .Include(ar => ar.Receiver)
            .Where(ar => ar.PetId == petId)
            .ToListAsync();
    }

    public async Task<List<AdoptionRequest>> GetPendingRequestsAsync()
    {
        return await _context.AdoptionRequests
            .Include(ar => ar.Pet)
            .Include(ar => ar.Initiator)
            .Include(ar => ar.Receiver)
            .Where(ar => ar.Status == AdoptionStatus.Pending)
            .OrderBy(ar => ar.RequestDate)
            .ToListAsync();
    }

    public async Task<bool> ExistsPendingRequestForPetAsync(string petId, string initiatorId)
    {
        return await _context.AdoptionRequests
            .AnyAsync(ar => ar.PetId == petId 
                && ar.InitiatorId == initiatorId 
                && ar.Status == AdoptionStatus.Pending);
    }
}