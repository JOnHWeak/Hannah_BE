using System.IO;
using System.Threading.Tasks;

namespace HannahAI.Infrastructure.Services;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(Stream stream, string fileName);
    Task DeleteFileAsync(string filePath);
}

public class FileStorageService : IFileStorageService
{
    private readonly string _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

    public FileStorageService()
    {
        if (!Directory.Exists(_uploadPath))
        {
            Directory.CreateDirectory(_uploadPath);
        }
    }

    public async Task<string> SaveFileAsync(Stream stream, string fileName)
    {
        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var filePath = Path.Combine(_uploadPath, uniqueFileName);

        await using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream);
        }

        return Path.Combine("uploads", uniqueFileName); // Return relative path
    }

    public Task DeleteFileAsync(string filePath)
    {
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        return Task.CompletedTask;
    }
}

