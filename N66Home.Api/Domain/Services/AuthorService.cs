using N66Home.Api.Domain.Entities;
using N66Home.Api.Domain.Services.Interfaces;

namespace N66Home.Api.Domain.Services;

public class AuthorService : IAuthorService
{
    public ValueTask<Author> CreateAsync(Author author)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Author> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Author>> GetAsync(IEnumerable<Author> authors)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Author> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Author> UpdateAsync(Author author)
    {
        throw new NotImplementedException();
    }
}
