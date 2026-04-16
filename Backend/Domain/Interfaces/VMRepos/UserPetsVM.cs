using PetShop.BackendV2.Domain.Entities.ViewModels;

namespace PetShop.BackendV2.Domain.Interfaces.VMRepos;

public interface IUserPetsVMRepo
{
    Task<List<PetResponseVM>> GetAllPetsOfUserAsync(string userId);
}
