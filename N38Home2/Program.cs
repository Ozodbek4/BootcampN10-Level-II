
using Bogus;

int idSeed = 1;
Faker<Employee> Fake = new Faker<Employee>()
    .RuleFor(employee => employee.Id, id => idSeed)
    .RuleFor(employee => employee.Name, name => name.Person.FullName)
    .RuleFor(employee => employee.WorkName, workName => workName.Company.CompanyName());

Faker<Order> Orders = new Faker<Order>()
    .RuleFor(order => order.Id, id => Guid.NewGuid())
    .RuleFor(order => order.ProductName, name => name.Lorem.Paragraph(1))
    .RuleFor(order => order.Price, price => price.Random.Decimal(1, 3000))
    .RuleFor(order => order.OrderDate, date => DateTime.Now);

Faker<UserAddress> UserAddresses = new Faker<UserAddress>()
    .RuleFor(userAddress => userAddress.StreetName, streetName => streetName.Person.Address.Street)
    .RuleFor(userAddress => userAddress.CityName, cityName => cityName.Person.Address.City)
    .RuleFor(userAddress => userAddress.CountryName, cityName => cityName.Person.Address.State);

Faker<BlogPost> Blogs = new Faker<BlogPost>()
    .RuleFor(blog => blog.Title, title => title.Lorem.Paragraph(5))
    .RuleFor(blog => blog.Body, title => title.Lorem.Paragraph(50));
Random random = new Random();

Faker<WeatherReport> Weather = new Faker<WeatherReport>()
    .RuleFor(weather => weather.DateTime, date => date.Date.Future())
    .RuleFor(weather => weather.AvarageTemperature, avarage => avarage.Random.Int(20, 50))
    .RuleFor(weather => weather.Condition, condition => Enum.GetNames(typeof(WeatherCondition))[random.Next(3)].WeatherEnumParse());
var a = Weather.Generate(3);
a.ForEach(x => Console.WriteLine($"{x.Condition} {x.AvarageTemperature} C"));

var b = Blogs.Generate(4);
b.ForEach(x => Console.WriteLine($"{x.Title} - {x.Body}"));

var c = Orders.Generate(5);
c.ForEach(x => Console.WriteLine($"{x.ProductName} {x.OrderDate} {x.Price}"));

var d = Fake.Generate(6);
d.ForEach(x => Console.WriteLine($"{x.Name} {x.WorkName}"));

static class StringExtencion
{
    public static WeatherCondition WeatherEnumParse(this string a)
    {
        return Enum.TryParse(a, out WeatherCondition result) ? result : WeatherCondition.Cloudy;
    }
}
public enum WeatherCondition
{
    Cloudy,
    Sunny,
    Windy,
    Rainy
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string WorkName { get; set; }
    
    public Employee() { }
    public Employee(int id, string name, string workName)
    {
        Id = id;
        Name = name;
        WorkName = workName;
    }
}

public class Order
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public DateTime OrderDate { get; set; }
    
    public Order() { }
    public Order(Guid id, string productName, decimal price, DateTime orderDate)
    {
        Id = id;
        ProductName = productName;
        Price = price;
        OrderDate = orderDate;
    }
}

public class UserAddress
{
    public string StreetName { get; set; }
    public string CityName { get; set; }
    public string CountryName { get; set; }

    public UserAddress() { }
    public UserAddress(string streetName, string cityName, string countryName)
    {
        StreetName = streetName;
        CityName = cityName;
        CountryName = countryName;
    }
}

public class BlogPost
{
    public string Title { get; set; }
    public string Body { get; set; }
    
    public BlogPost() { }
    public BlogPost(string title, string body)
    {
        Title = title;
        Body = body;
    }
}

public class WeatherReport
{
    public DateTime DateTime { get; set; }
    public double AvarageTemperature { get; set; }
    public WeatherCondition Condition;
    public WeatherReport() { }
    public WeatherReport(DateTime dateTime, double avarageTemperature, WeatherCondition condition)
    {
        DateTime = dateTime;
        AvarageTemperature = avarageTemperature;
        Condition = condition;
    }

}