namespace PetShop.BackendV2.Domain.Interfaces.Services;

public interface IFileService
{
    /// <summary>
    /// Uploads a file and returns the public URL or relative path.
    /// </summary>
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string folder);
    
    /// <summary>
    /// Deletes a file given its path or URL.
    /// </summary>
    Task DeleteFileAsync(string filePath);
}
