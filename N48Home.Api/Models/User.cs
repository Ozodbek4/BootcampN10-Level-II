using FileBaseContext.Abstractions.Models.Entity;

namespace N48Home.Api.Models;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }

    public bool IsDeleted { get; set; }

    public User(Guid id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        IsDeleted = false;
    }
}