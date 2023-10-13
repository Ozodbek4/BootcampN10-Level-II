using FileBaseContext.Abstractions.Models.FileSet;
using N48Home.Api.Models;

namespace N48Home.Api.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    IFileSet<Order, Guid> Orders { get; }

    ValueTask SaveChangesAsync();
}