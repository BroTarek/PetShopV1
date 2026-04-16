using PetShop.BackendV2.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;

namespace PetShop.BackendV2.Infrastructure.Services;

public class LocalFileService : IFileService
{
    private readonly IWebHostEnvironment _environment;

    public LocalFileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string folder)
    {
        var uploadsFolder = Path.Combine(_environment.WebRootPath ?? "wwwroot", folder);
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var file = new FileStream(filePath, FileMode.Create))
        {
            await fileStream.CopyToAsync(file);
        }

        return Path.Combine(folder, uniqueFileName).Replace("\\", "/");
    }

    public Task DeleteFileAsync(string filePath)
    {
        var fullPath = Path.Combine(_environment.WebRootPath ?? "wwwroot", filePath);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        return Task.CompletedTask;
    }
}
