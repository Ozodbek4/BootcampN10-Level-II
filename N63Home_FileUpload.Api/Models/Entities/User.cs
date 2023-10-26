namespace N63Home_FileUpload.Api.Models.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public byte Age { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }
}