using Microsoft.EntityFrameworkCore;
using N66DataBase.Domain.Models;

namespace N66DataBase.Persistence.DataContext;

internal class AppDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Author> Authors => Set<Author>();

    // Database connection configuration
    // 1-usuli - internal configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // write postgres connection string
        // Server=localhost;Database=MyFirstEfCoreApp;User=postgres;Password=postgres - sql server
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyFirstEfCoreApp;Username=postgres;Password=postgres");
        // Host=localhost;Port=5432;Database=MyFirstEfCoreApp;Username=postgres;Password=postgres - postgres
        base.OnConfiguring(optionsBuilder);
    }

    // Relationship configuration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // one-to-one relationship
        // modelBuilder.Entity<UserSettings>().HasOne<User>();
        // modelBuilder.Entity<UserSettings>().HasForeignKey(userSettings => userSettings.UserId);

        // one-to-many relationship
        modelBuilder.Entity<Book>().HasOne(book => book.Author).WithMany();
        base.OnModelCreating(modelBuilder);

    }
}
