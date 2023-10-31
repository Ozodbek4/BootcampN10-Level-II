using N66Home.Api.Domain.Entities;
using N66Home.Api.Persistence.DataContext;

namespace N66Home.Api.Persistence.SeedData;

public class SeedDataService
{
    public async void SeedDataDb(AppDbContext appDataContext)
    {
        if (appDataContext.Author.Any())
        {
            appDataContext.Author.AddRange(new Author
            {
                FirstName = "Navoiy",
                LastName = "Alisher",
            },
            new Author
            {
                FirstName = "O'tkir",
                LastName = "Hoshimov",
            });

            await appDataContext.SaveChangesAsync();
        }

        if (appDataContext.Books.Any())
        {
            appDataContext.Books.AddRange(new Book
            {
                Title = "Xamsa",
                Description = "Doston",
                AuthorId = appDataContext.Author.First().Id,
            },
            new Book
            {
                Title = "Sariq devni minib",
                Description = "Asar",
                AuthorId = appDataContext.Author.Skip(1).First().Id,
            });
        }
    }
}