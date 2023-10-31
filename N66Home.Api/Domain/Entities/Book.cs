namespace N66Home.Api.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public virtual Author Author { get; set; }

    public Guid AuthorId { get; set; }

    public bool IsDeleted { get; set; } = false;
}