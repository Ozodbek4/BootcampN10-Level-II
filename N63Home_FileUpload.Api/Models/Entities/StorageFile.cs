namespace N63Home_FileUpload.Api.Models.Entities;

public class StorageFile
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FileName { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
}