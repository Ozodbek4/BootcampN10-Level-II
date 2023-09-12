
Person person = new Student("Aziz", "Aliyev", 2);   
person.Deconstruct(out string firstName, out string lastName);
(string firstName1, string lastName1) = person;
(string firstName2, string lastName2) person1 = ("", "");




public record Person(string FirstName, string LastName);
public record Student(string FirstName, string LastName, int grade) :
    Person(FirstName, LastName);

public record Teacher(string FirstName, string LastName, int Experience)
