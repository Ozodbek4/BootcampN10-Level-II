using N66Home.Api.Domain.Entities;
using N66Home.Api.Domain.Services.Interfaces;

namespace N66Home.Api.Domain.Services;

public class BookService : IBookService
{
    public ValueTask<Book> CreateAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Book> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Book>> GetAsync(IEnumerable<Book> books)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Book> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Book> UpdateAsync(Book book)
    {
        throw new NotImplementedException();
    }
}