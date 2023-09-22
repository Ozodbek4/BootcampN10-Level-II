using N43Home1.Models;
using N43Home1.Services;

var userService = new UserService();
var user = userService.AddUser(new User("Jacky", "Chan"));
var userA= userService.AddUser(new User("Jacky", "Chan"));
var userB= userService.AddUser(new User("Jacky", "Chan"));
var accountService = new AccountService(userService);
accountService.CreateReportAsync(user.Id);
