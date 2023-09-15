using Bogus;
using N39Task1;

int idSeed = 1;

if (idSeed == 1)
{
    throw new Exception("b");
}
Faker<Student> Students = new Faker<Student>()
    .RuleFor(student => student.Id, id => idSeed)
    .RuleFor(student => student.FirstName, name => name.Person.FirstName)
    .RuleFor(student => student.LastName, name => name.Person.LastName)
    .RuleFor(student => student.Description, description => description.Lorem.Paragraph(10));
var studentsUniversity = Students.Generate(10);

foreach (var student in studentsUniversity)
{
    //Console.WriteLine($"{} {} {} {}");
}