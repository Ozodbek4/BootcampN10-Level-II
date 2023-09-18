
using Bogus;

int idSeed = 1;
Faker<Employee> fake = new Faker<Employee>()
    .RuleFor(employee => employee.Id, id => idSeed)
    .RuleFor(employee => employee.Name, name => name.Person.FullName)
    .RuleFor(employee => employee.WorkName, workName => workName.Company.CompanyName());


public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string WorkName { get; set; }
    
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
    public string Condition { get; set; }

    public WeatherReport(DateTime dateTime, double avarageTemperature, string condition)
    {
        DateTime = dateTime;
        AvarageTemperature = avarageTemperature;
        Condition = condition;
    }

}