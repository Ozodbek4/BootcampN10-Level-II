using N66Home.Api.Domain.Entities;
using N66Home.Api.Persistence.DataContext;
using System.Text.Json;
using System;
using Microsoft.EntityFrameworkCore;

namespace N66Home.Api.Persistence.SeedData;

public class SeedDataService
{
    private readonly AppDbContext _appDbContext;

    public SeedDataService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        SeedDataDb();
    }

    public async void SeedDataDb()
    {
        if (_appDbContext.Author.Any())
        {
            _appDbContext.Author.AddRange(new Author
            {
                FirstName = "Navoiy",
                LastName = "Alisher",
            },
            new Author
            {
                FirstName = "O'tkir",
                LastName = "Hoshimov",
            });

            await _appDbContext.SaveChangesAsync();
        }

        if (_appDbContext.Books.Any())
        {
            _appDbContext.Books.AddRange(new Book
            {
                Title = "Xamsa",
                Description = "Doston",
                AuthorId = _appDbContext.Author.First().Id,
            },
            new Book
            {
                Title = "Sariq devni minib",
                Description = "Asar",
                AuthorId = _appDbContext.Author.Skip(1).First().Id,
            });
        }
        var allBooks = await _appDbContext.Books
            .Include(book => book.Author)
            .ToListAsync();
        Console.WriteLine(JsonSerializer.Serialize(allBooks));
    }
}