using N66Home.Api.Domain.Entities;
using N66Home.Api.Domain.Services.Interfaces;
using N66Home.Api.Persistence.DataContext;

namespace N66Home.Api.Domain.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _dbContext;

    public BookService(AppDbContext dbContext) =>
        _dbContext = dbContext;

    public ValueTask<Book> GetById(Guid id)
    {
        var book = _dbContext.Books.FirstOrDefault(booked => booked.Id == id);

        if (book is null)
            throw new ArgumentNullException("Author is not found");

        return new ValueTask<Book>(book);
    }

    public ValueTask<IEnumerable<Book>> GetAsync() =>
        new ValueTask<IEnumerable<Book>>(_dbContext.Books);

    public async ValueTask<Book> CreateAsync(Book book)
    {
        if (_dbContext.Books.Any(auth => auth.Id == book.Id))
            throw new ArgumentOutOfRangeException("Book is already exists");

        _dbContext.Books.AddRange(book);
        await _dbContext.SaveChangesAsync();

        return book;
    }

    public async ValueTask<Book> UpdateAsync(Book book)
    {
        var updatedBook = await GetById(book.Id);

        updatedBook.Title = book.Title;
        updatedBook.Description = book.Description;
        updatedBook.Author = book.Author;
        updatedBook.AuthorId = book.AuthorId;

        return updatedBook;
    }

    public async ValueTask<Book> DeleteAsync(Guid id)
    {
        var deletedBook = await GetById(id);

        deletedBook.IsDeleted = true;

        return deletedBook;
    }
}