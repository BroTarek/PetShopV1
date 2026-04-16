using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.Application.Interfaces.VMRepos;

public interface IUserPetsVMRepo
{
    Task<List<PetResponseVM>> GetAllPetsOfUserAsync(string userId);
}
