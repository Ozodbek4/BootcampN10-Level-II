public record Person(string FirstName, string LastName);

public record Employee(string FirstName, string LastName, bool IsWork)
    : Person(FirstName, LastName);

public record Manager(string FirstName, string LastName, decimal Salary)
    : Person(FirstName, LastName);