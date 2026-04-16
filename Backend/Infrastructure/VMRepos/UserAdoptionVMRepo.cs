using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities.ViewModels;
using PetShop.BackendV2.Application.Interfaces.VMRepos;
using PetShop.BackendV2.Infrastructure.Data;
using PetShop.BackendV2.Domain.Enums;

namespace PetShop.BackendV2.Infrastructure.VMRepos;

public class UserAdoptionVMRepo : IUserAdoptionVMRepo
{
    private readonly AppDbContext _context;

    public UserAdoptionVMRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserAdoptionRequestVM>> GetInitiatedRequestsVMAsync(string userId)
    {
        return await _context.AdoptionRequests
            .Where(ar => ar.InitiatorId == userId)
            .OrderByDescending(ar => ar.RequestDate)
            .Select(ar => new UserAdoptionRequestVM
            {
                RequestId = ar.Id,
                PetName = ar.Pet.Name,
                PetImageUrl = ar.Pet.Images.FirstOrDefault() ?? string.Empty,
                InitiatorName = ar.Initiator.FirstName + " " + ar.Initiator.LastName,
                InitiatorEmail = ar.Initiator.Email,
                ReceiverName = ar.Receiver.FirstName + " " + ar.Receiver.LastName,
                Status = ar.Status.ToString(),
                RequestDate = ar.RequestDate,
                PetHealthStatus = ar.Pet.HealthStatus.ToString(),
                DecisionDate = ar.DecisionDate
            })
            .ToListAsync();
    }

    public async Task<List<UserAdoptionRequestVM>> GetReceivedRequestsVMAsync(string userId)
    {
        return await _context.AdoptionRequests
            .Where(ar => ar.ReceiverId == userId)
            .OrderByDescending(ar => ar.RequestDate)
            .Select(ar => new UserAdoptionRequestVM
            {
                RequestId = ar.Id,
                PetName = ar.Pet.Name,
                PetImageUrl = ar.Pet.Images.FirstOrDefault() ?? string.Empty,
                InitiatorName = ar.Initiator.FirstName + " " + ar.Initiator.LastName,
                InitiatorEmail = ar.Initiator.Email,
                ReceiverName = ar.Receiver.FirstName + " " + ar.Receiver.LastName,
                Status = ar.Status.ToString(),
                RequestDate = ar.RequestDate,
                PetHealthStatus = ar.Pet.HealthStatus.ToString(),
                DecisionDate = ar.DecisionDate
            })
            .ToListAsync();
    }

    public async Task<UserAdoptionRequestVM?> GetRequestByIdVMAsync(string requestId)
    {
        return await _context.AdoptionRequests
            .Where(ar => ar.Id == requestId)
            .Select(ar => new UserAdoptionRequestVM
            {
                RequestId = ar.Id,
                PetName = ar.Pet.Name,
                PetImageUrl = ar.Pet.Images.FirstOrDefault() ?? string.Empty,
                InitiatorName = ar.Initiator.FirstName + " " + ar.Initiator.LastName,
                InitiatorEmail = ar.Initiator.Email,
                ReceiverName = ar.Receiver.FirstName + " " + ar.Receiver.LastName,
                Status = ar.Status.ToString(),
                RequestDate = ar.RequestDate,
                PetHealthStatus = ar.Pet.HealthStatus.ToString(),
                DecisionDate = ar.DecisionDate
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<UserAdoptionRequestVM>> GetAllPendingRequestsVMAsync()
    {
        return await _context.AdoptionRequests
            .Where(ar => ar.Status == AdoptionStatus.Pending)
            .OrderBy(ar => ar.RequestDate)
            .Select(ar => new UserAdoptionRequestVM
            {
                RequestId = ar.Id,
                PetName = ar.Pet.Name,
                PetImageUrl = ar.Pet.Images.FirstOrDefault() ?? string.Empty,
                InitiatorName = ar.Initiator.FirstName + " " + ar.Initiator.LastName,
                InitiatorEmail = ar.Initiator.Email,
                ReceiverName = ar.Receiver.FirstName + " " + ar.Receiver.LastName,
                Status = ar.Status.ToString(),
                RequestDate = ar.RequestDate,
                PetHealthStatus = ar.Pet.HealthStatus.ToString(),
                DecisionDate = ar.DecisionDate
            })
            .ToListAsync();
    }
}
