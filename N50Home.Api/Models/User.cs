namespace N50Home.Api.Models;

public class User
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string EmailAddress { get; set; }
    
    public bool IsDeleted { get; set; }

    public User(Guid id, string firstName, string lastName, string emailAddress, bool isActived)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        IsDeleted = isActived;
    }
}