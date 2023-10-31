using N66Home.Api.Domain.Entities;
using N66Home.Api.Domain.Services.Interfaces;
using N66Home.Api.Persistence.DataContext;

namespace N66Home.Api.Domain.Services;

public class AuthorService : IAuthorService
{
    private readonly AppDbContext _dbContext;

    public AuthorService(AppDbContext dbContext) =>
        _dbContext = dbContext;

    public ValueTask<Author> GetById(Guid id)
    {
        var author = _dbContext.Author.FirstOrDefault(auth => auth.Id == id);

        if (author is null)
            throw new ArgumentNullException("Author is not found");

        return new ValueTask<Author>(author);
    }

    public ValueTask<IEnumerable<Author>> GetAsync(IEnumerable<Author> authors) =>
        new ValueTask<IEnumerable<Author>>(_dbContext.Author);

    public async ValueTask<Author> CreateAsync(Author author)
    {
        if (_dbContext.Author.Any(auth => auth.Id == author.Id))
            throw new ArgumentOutOfRangeException("Author is already exists");

        _dbContext.Author.AddRange(author);
        await _dbContext.SaveChangesAsync();

        return author;
    }

    public async ValueTask<Author> UpdateAsync(Author author)
    {
        var updateAuthor = await GetById(author.Id);

        updateAuthor.FirstName = author.FirstName;
        updateAuthor.LastName = author.LastName;

        return updateAuthor;
    }

    public async ValueTask<Author> DeleteAsync(Guid id)
    {
        var deletedAuthor = await GetById(id);

        deletedAuthor.IsDeleted = true;

        return deletedAuthor;
    }
}
