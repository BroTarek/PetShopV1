using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Infrastructure.Data;

namespace PetShop.BackendV2.Application.Services;

public class AdoptionRequestService
{
    private readonly IAdoptionRequestRepository _adoptionRequestRepo;
    private readonly IPetRepository _petRepo;
    private readonly IUserRepository _userRepo;
    private readonly AppDbContext _context;

    public AdoptionRequestService(
        IAdoptionRequestRepository adoptionRequestRepo,
        IPetRepository petRepo,
        IUserRepository userRepo,
        AppDbContext context)
    {
        _adoptionRequestRepo = adoptionRequestRepo;
        _petRepo = petRepo;
        _userRepo = userRepo;
        _context = context;
    }

    public async Task<AdoptionRequest> InitiateAdoptionRequestAsync(
        string petId, 
        string initiatorId, 
        string receiverId)
    {
        // Validation
        if (string.IsNullOrEmpty(petId))
            throw new ArgumentException("Pet ID is required");
        if (string.IsNullOrEmpty(initiatorId))
            throw new ArgumentException("Initiator ID is required");
        if (string.IsNullOrEmpty(receiverId))
            throw new ArgumentException("Receiver ID is required");
        
        if (initiatorId == receiverId)
            throw new InvalidOperationException("Cannot request adoption from yourself");

        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            // 1. Validate pet exists and is available
            var pet = await _petRepo.GetByIdAsync(petId);
            if (pet == null)
                throw new KeyNotFoundException($"Pet with ID {petId} not found");
            
            if (pet.Status != PetStatus.Available)
                throw new InvalidOperationException($"Pet is not available for adoption (Current status: {pet.Status})");
            
            // 2. Validate users exist
            var initiator = await _userRepo.GetByIdAsync(initiatorId);
            var receiver = await _userRepo.GetByIdAsync(receiverId);
            
            if (initiator == null)
                throw new KeyNotFoundException($"Initiator user with ID {initiatorId} not found");
            if (receiver == null)
                throw new KeyNotFoundException($"Receiver user with ID {receiverId} not found");
            
            // 3. Check if user already has pending request for this pet
            var existingRequest = await _adoptionRequestRepo.ExistsPendingRequestForPetAsync(petId, initiatorId);
            if (existingRequest)
                throw new InvalidOperationException("You already have a pending adoption request for this pet");
            
            // 4. Create adoption request
            var adoptionRequest = new AdoptionRequest
            {
                Id = Guid.NewGuid().ToString(),
                PetId = petId,
                Pet = pet,
                InitiatorId = initiatorId,
                Initiator = initiator,
                ReceiverId = receiverId,
                Receiver = receiver,
                Status = AdoptionStatus.Pending,
                RequestDate = DateTime.UtcNow
            };
            
            // 5. Save to database
            await _adoptionRequestRepo.CreateAsync(adoptionRequest);
            
            // 6. Update navigation collections
            if (initiator.AdoptionRequestsInitiated == null)
                initiator.AdoptionRequestsInitiated = new List<AdoptionRequest>();
            if (receiver.AdoptionRequestsReceived == null)
                receiver.AdoptionRequestsReceived = new List<AdoptionRequest>();
                
            initiator.AdoptionRequestsInitiated.Add(adoptionRequest);
            receiver.AdoptionRequestsReceived.Add(adoptionRequest);
            
            await _userRepo.UpdateAsync(initiator);
            await _userRepo.UpdateAsync(receiver);
            
            // 7. Save all changes atomically
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
            return adoptionRequest;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<AdoptionRequest> AcceptAdoptionRequestAsync(string requestId)
    {
        if (string.IsNullOrEmpty(requestId))
            throw new ArgumentException("Request ID is required");

        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            // 1. Get the adoption request with all related data
            var adoptionRequest = await _adoptionRequestRepo.GetByIdAsync(requestId);
            if (adoptionRequest == null)
                throw new KeyNotFoundException($"Adoption request with ID {requestId} not found");
            
            // 2. Check if request is still pending
            if (adoptionRequest.Status != AdoptionStatus.Pending)
                throw new InvalidOperationException($"Cannot accept request that is already {adoptionRequest.Status}");
            
            // 3. Get fresh pet data
            var pet = await _petRepo.GetByIdAsync(adoptionRequest.PetId);
            if (pet == null)
                throw new KeyNotFoundException("Pet associated with this request no longer exists");
            
            // 4. Check if pet is still available
            if (pet.Status != PetStatus.Available)
                throw new InvalidOperationException($"Pet is no longer available for adoption (Status: {pet.Status})");
            
            // 5. Get users with their collections
            var initiator = await _userRepo.GetByIdWithIncludesAsync(adoptionRequest.InitiatorId);
            var receiver = await _userRepo.GetByIdWithIncludesAsync(adoptionRequest.ReceiverId);
            
            if (initiator == null || receiver == null)
                throw new KeyNotFoundException("User not found");
            
            // 6. Transfer pet ownership
            receiver.Pets?.Remove(pet);
            initiator.Pets ??= new List<Pet>();
            initiator.Pets.Add(pet);
            pet.OwnerId = initiator.Id;
            pet.Status = PetStatus.Adopted;
            
            // 7. Update adoption request status
            adoptionRequest.Status = AdoptionStatus.Approved;
            adoptionRequest.DecisionDate = DateTime.UtcNow;
            
            // 8. Remove request from both users' collections
            initiator.AdoptionRequestsInitiated?.Remove(adoptionRequest);
            receiver.AdoptionRequestsReceived?.Remove(adoptionRequest);
            
            // 9. Save all changes
            await _petRepo.UpdateAsync(pet);
            await _userRepo.UpdateAsync(initiator);
            await _userRepo.UpdateAsync(receiver);
            await _adoptionRequestRepo.UpdateAsync(adoptionRequest);
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
            return adoptionRequest;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<AdoptionRequest> RejectAdoptionRequestAsync(string requestId)
    {
        if (string.IsNullOrEmpty(requestId))
            throw new ArgumentException("Request ID is required");

        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            var adoptionRequest = await _adoptionRequestRepo.GetByIdAsync(requestId);
            if (adoptionRequest == null)
                throw new KeyNotFoundException($"Adoption request with ID {requestId} not found");
            
            if (adoptionRequest.Status != AdoptionStatus.Pending)
                throw new InvalidOperationException($"Cannot reject request that is already {adoptionRequest.Status}");
            
            var initiator = await _userRepo.GetByIdAsync(adoptionRequest.InitiatorId);
            var receiver = await _userRepo.GetByIdAsync(adoptionRequest.ReceiverId);
            
            if (initiator == null || receiver == null)
                throw new KeyNotFoundException("User not found");
            
            // Update status
            adoptionRequest.Status = AdoptionStatus.Rejected;
            adoptionRequest.DecisionDate = DateTime.UtcNow;
            
            // Remove from both users' collections
            initiator.AdoptionRequestsInitiated?.Remove(adoptionRequest);
            receiver.AdoptionRequestsReceived?.Remove(adoptionRequest);
            
            await _userRepo.UpdateAsync(initiator);
            await _userRepo.UpdateAsync(receiver);
            await _adoptionRequestRepo.UpdateAsync(adoptionRequest);
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
            return adoptionRequest;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<AdoptionRequest> CancelAdoptionRequestAsync(string requestId)
    {
        if (string.IsNullOrEmpty(requestId))
            throw new ArgumentException("Request ID is required");

        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            var adoptionRequest = await _adoptionRequestRepo.GetByIdAsync(requestId);
            if (adoptionRequest == null)
                throw new KeyNotFoundException($"Adoption request with ID {requestId} not found");
            
            // Only initiator can cancel, and only if pending
            if (adoptionRequest.Status != AdoptionStatus.Pending)
                throw new InvalidOperationException($"Cannot cancel request that is already {adoptionRequest.Status}");
            
            var initiator = await _userRepo.GetByIdAsync(adoptionRequest.InitiatorId);
            var receiver = await _userRepo.GetByIdAsync(adoptionRequest.ReceiverId);
            
            if (initiator == null || receiver == null)
                throw new KeyNotFoundException("User not found");
            
            // Soft delete - mark as cancelled instead of deleting
            adoptionRequest.Status = AdoptionStatus.Cancelled;
            adoptionRequest.DecisionDate = DateTime.UtcNow;
            
            // Remove from both users' collections
            initiator.AdoptionRequestsInitiated?.Remove(adoptionRequest);
            receiver.AdoptionRequestsReceived?.Remove(adoptionRequest);
            
            await _userRepo.UpdateAsync(initiator);
            await _userRepo.UpdateAsync(receiver);
            await _adoptionRequestRepo.UpdateAsync(adoptionRequest);
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
            return adoptionRequest;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<AdoptionRequest> GetAdoptionRequestByIdAsync(string requestId)
    {
        var request = await _adoptionRequestRepo.GetByIdAsync(requestId);
        if (request == null)
            throw new KeyNotFoundException($"Adoption request with ID {requestId} not found");
        
        return request;
    }
}