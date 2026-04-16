using Microsoft.AspNetCore.Mvc;
using PetShop.BackendV2.Application.Services;
using PetShop.BackendV2.Application.Interfaces.VMRepos;

namespace PetShop.BackendV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdoptionController : ControllerBase
{
    private readonly AdoptionRequestService _adoptionService;
    private readonly IUserAdoptionVMRepo _userAdoptionVMRepo;

    public AdoptionController(
        AdoptionRequestService adoptionService,
        IUserAdoptionVMRepo userAdoptionVMRepo)
    {
        _adoptionService = adoptionService;
        _userAdoptionVMRepo = userAdoptionVMRepo;
    }

    [HttpPost("initiate")]
    public async Task<IActionResult> InitiateAdoption([FromBody] InitiateAdoptionRequest request)
    {
        try
        {
            var adoptionRequest = await _adoptionService.InitiateAdoptionRequestAsync(
                request.PetId,
                request.InitiatorUserId,
                request.ReceiverUserId
            );
            
            return Ok(new 
            { 
                RequestId = adoptionRequest.Id, 
                Status = adoptionRequest.Status.ToString(),
                Message = "Adoption request initiated successfully"
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { Error = ex.Message });
        }
    }

    [HttpPut("{requestId}/accept")]
    public async Task<IActionResult> AcceptAdoptionRequest(string requestId)
    {
        try
        {
            var adoptionRequest = await _adoptionService.AcceptAdoptionRequestAsync(requestId);
            return Ok(new 
            { 
                RequestId = adoptionRequest.Id, 
                Status = adoptionRequest.Status.ToString(),
                Message = "Adoption request accepted successfully"
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { Error = ex.Message });
        }
    }

    [HttpPut("{requestId}/reject")]
    public async Task<IActionResult> RejectAdoptionRequest(string requestId)
    {
        try
        {
            var adoptionRequest = await _adoptionService.RejectAdoptionRequestAsync(requestId);
            return Ok(new 
            { 
                RequestId = adoptionRequest.Id, 
                Status = adoptionRequest.Status.ToString(),
                Message = "Adoption request rejected"
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { Error = ex.Message });
        }
    }

    [HttpPut("{requestId}/cancel")]
    public async Task<IActionResult> CancelAdoptionRequest(string requestId)
    {
        try
        {
            var adoptionRequest = await _adoptionService.CancelAdoptionRequestAsync(requestId);
            return Ok(new 
            { 
                RequestId = adoptionRequest.Id, 
                Status = adoptionRequest.Status.ToString(),
                Message = "Adoption request cancelled"
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { Error = ex.Message });
        }
    }

    [HttpGet("user/{userId}/initiated")]
    public async Task<IActionResult> GetUserInitiatedAdoptionRequests(string userId)
    {
        var requests = await _userAdoptionVMRepo.GetInitiatedRequestsVMAsync(userId);
        return Ok(requests);
    }

    [HttpGet("user/{userId}/received")]
    public async Task<IActionResult> GetUserReceivedAdoptionRequests(string userId)
    {
        var requests = await _userAdoptionVMRepo.GetReceivedRequestsVMAsync(userId);
        return Ok(requests);
    }

    [HttpGet("{requestId}")]
    public async Task<IActionResult> GetAdoptionRequestById(string requestId)
    {
        var request = await _userAdoptionVMRepo.GetRequestByIdVMAsync(requestId);
        if (request == null)
            return NotFound(new { Error = $"Adoption request with ID {requestId} not found" });
        
        return Ok(request);
    }

    [HttpGet("pending")]
    public async Task<IActionResult> GetAllPendingRequests()
    {
        var requests = await _userAdoptionVMRepo.GetAllPendingRequestsVMAsync();
        return Ok(requests);
    }
}

public class InitiateAdoptionRequest
{
    public string PetId { get; set; } = string.Empty;
    public string InitiatorUserId { get; set; } = string.Empty;
    public string ReceiverUserId { get; set; } = string.Empty;
}
