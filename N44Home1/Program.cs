//N44 - HT1

//- bajarilishiga 20 sekunddan ko'p vaqt ketadigan biror komandani o'ylang, shu bo'yicha service va methodni yarating ( task,.delay bo'lsa ham bo'laveradi) 
//- asosiy main methodda 5 sekund delay bor bo'lgan cancellation token source yarating va methodga parameter orqali ichidagi tokenni berib yuboring
//- dasturni ishlatib method ishlashi 5 sek dan keyin cancel bo'lishini tekshiring

//N44-HT2

//- LINQ dagi deferred, immediate va mixed execution ga 3 tadan misol yozing




using N44Home2.Models;
using Bogus;

var user = new Faker<User>()
    .RuleFor(user => user.PhoneNumber, usering => usering.Person.Phone);

var users = user.Generate(2);

foreach(var use in users)
{
    Console.WriteLine(use.PhoneNumber);
}




//List<User> users = new List<User>()
//{
//    new User(1, "Doe", "Stiven", "doestiven04@gmail.com", true),
//    new User(2, "John", "Stiven", "johnstiven04@gmail.com", false),
//    new User(3, "Tom", "Stiven", "tomstiven04@gmail.com", true),
//    new User(4, "Sarah", "Stiven", "sarahstiven04@gmail.com", true),
//    new User(5, "Alex", "Stiven", "alexstiven04@gmail.com", false),
//};

//// linq deferred ga misollar
//var deferredExecution = users.Where(item => item.IsNeighbor);
//deferredExecution.ToList().ForEach(item => Console.WriteLine(item.ToString()));

//// linq immediate
//var immediate = users.Count(item => !item.IsNeighbor);
//Console.WriteLine(immediate);

//// linq mixed

//var mixed = users.OrderByDescending(item => item.FirstName).First();
//Console.WriteLine(mixed);