using N66Home.Api.Domain.Entities;

namespace N66Home.Api.Domain.Services.Interfaces;

public interface IBookService
{
    ValueTask<Book> GetById(Guid id);

    ValueTask<IEnumerable<Book>> GetAsync();

    ValueTask<Book> CreateAsync(Book book);

    ValueTask<Book> UpdateAsync(Book book);

    ValueTask<Book> DeleteAsync(Guid id);
}