using Microsoft.Extensions.DependencyInjection;
using PetShop.BackendV2.Application.Services;

namespace PetShop.BackendV2.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddScoped<AdoptionRequestService>();
        services.AddScoped<FavouriteService>();
        services.AddScoped<PostService>();
        services.AddScoped<ReviewService>();
        services.AddScoped<PetService>();
        services.AddScoped<UserService>();
        services.AddScoped<AuthService>();
        services.AddScoped<AdminService>();
        
        return services;
    }
}