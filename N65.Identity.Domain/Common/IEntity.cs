using FileBaseContext.Abstractions.Models.Entity;

namespace N65.Identity.Domain.Common;

public interface IEntity : IFileSetEntity<Guid>
{
}