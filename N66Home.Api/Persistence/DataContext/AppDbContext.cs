using Microsoft.EntityFrameworkCore;
using N66Home.Api.Domain.Entities;

namespace N66Home.Api.Persistence.DataContext;

public class AppDbContext : DbContext
{
    public DbSet<Author> Author => Set<Author>();

    public DbSet<Book> Books => Set<Book>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;DataBase=MyFisrtDbHomeTask;UserName=postgres;Password=postgres;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasOne(book => book.Author).WithMany();
        base.OnModelCreating(modelBuilder);
    }
}