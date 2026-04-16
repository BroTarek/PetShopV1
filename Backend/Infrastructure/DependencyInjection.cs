using Microsoft.Extensions.DependencyInjection;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Domain.Interfaces.Services;
using PetShop.BackendV2.Application.Interfaces.VMRepos;
using PetShop.BackendV2.Infrastructure.Repositories;
using PetShop.BackendV2.Infrastructure.Services;
using PetShop.BackendV2.Infrastructure.VMRepos;

namespace PetShop.BackendV2.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureCore(this IServiceCollection services)
    {
        services.AddScoped<IAdoptionRequestRepository, AdoptionRequestRepository>();
        services.AddScoped<IUserAdoptionVMRepo, UserAdoptionVMRepo>();
        services.AddScoped<IFavouriteRepository, FavouriteRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IPetRepository, PetRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        
        // Add LocalFileService explicitly since the domain interface is defined as IFileService
        services.AddScoped<IFileService, LocalFileService>();

        return services;
    }
}
