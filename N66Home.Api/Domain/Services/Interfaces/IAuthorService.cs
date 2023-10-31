using N66Home.Api.Domain.Entities;

namespace N66Home.Api.Domain.Services.Interfaces;

public interface IAuthorService
{
    ValueTask<Author> GetById(Guid id);

    ValueTask<IEnumerable<Author>> GetAsync();

    ValueTask<Author> CreateAsync(Author author);

    ValueTask<Author> UpdateAsync(Author author);

    ValueTask<Author> DeleteAsync(Guid id);
}