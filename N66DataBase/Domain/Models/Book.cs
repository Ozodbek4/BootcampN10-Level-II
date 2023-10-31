using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N66DataBase.Domain.Models;

internal class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Guid AuthorId { get; set; }

    public virtual Author Author { get; set; }
}
