using FileBaseContext.Abstractions.Models.FileSet;
using N65.Identity.Domain.Entities;

namespace N65.Identity.Persistence.DataContexts;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    IFileSet<UserCredentials, Guid> UserCredentials { get; }
}