using N65.Identity.Domain.Common;

namespace N65.Identity.Domain.Entities;

public class User : AuditableEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }
}