namespace N53Home1.Models;

internal class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public decimal? Achievment { get; set; }
}