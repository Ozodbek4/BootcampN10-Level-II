using N63Home_FileUpload.Api.Models.Entities;

namespace N63Home_FileUpload.Api.Services;

public class StorageFileService
{
    private readonly IWebHostEnvironment _environment;

    public StorageFileService(IWebHostEnvironment environment) =>
        _environment = environment;


    public async ValueTask<StorageFile> Create(Guid userId, string directoryName, IFormFile fileStream)
    {
        var image = File.Create(Path.Combine(ExistsDirectory(userId, directoryName), fileStream.FileName));
        fileStream.CopyTo(image);

        return await new ValueTask<StorageFile> (new StorageFile
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            FileName = fileStream.FileName,
            CreatedDate = DateTimeOffset.Now,
        });
    }

    public async ValueTask<bool> Delete(string filePath)
    {
        if (Path.Exists(filePath))
        {
            File.Delete(filePath);
            return await new ValueTask<bool>(true);
        }

        return await new ValueTask<bool>(false);
    }

    private string ExistsDirectory(Guid userId, string directoryName)
    {
        var userPath = Path.Combine(_environment.WebRootPath, "User");

        if (!Directory.Exists(userPath))
            Directory.CreateDirectory(userPath);

        var userProfilePath = Path.Combine(userPath, userId.ToString(), directoryName);
        Directory.CreateDirectory(userProfilePath);

        return userProfilePath;
    }
}