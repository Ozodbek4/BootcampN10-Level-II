using System.IO.Compression;

(string Title, string Author, int Year) Book = ("", "", 1);
Book.Author.ToLower();
var Book1 = Tuple.Create("s", "njk");
Book.Item1.ToLower();

public record Person(string FullName, byte Age, string Address);

public struct Point
{
    public int X; 
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public record Order(Guid Id, Customer Customer, string Items);

public record Product(Guid Id, string Name, decimal Price);

public record Customer(string CustomerName, string CustomerEmail, string CustomerPhoneNumber);

public record Address(string AddressStreet, string AddressCity, string AddressState, ZipArchive ZipCode);

public record Invoice(Guid Id, Customer Customer, decimal TotalAmount);

