using N65.Identity.Domain.Common;

namespace N65.Identity.Domain.Entities;

public class UserCredentials : AuditableEntity
{
    public Guid UserId { get; set; }

    public string Password { get; set; }
}