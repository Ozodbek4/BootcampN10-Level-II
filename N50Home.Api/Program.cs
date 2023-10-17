using N50Home.Api.Models;
using N50Home.Api.Services;
using N50Home.Api.DataAccess;
using N50Home.Api.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var users = new List<User>
//{
//    new User("Bob"),
//    new User("John"),
//    new User("Wick"),
//    new User("Garry"),
//};

//var orders = new List<Order>
//{
//    new Order(users[0].Id),
//    new Order(users[1].Id),
//    new Order(users[0].Id),
//    new Order(users[2].Id),
//};

//var userService = new UserService(users);
//var orderService = new OrderService(orders);
//builder.Services.AddControllers();
//builder.Services.AddScoped<IUserService, UserService>(_ => userService);
//builder.Services.AddScoped<IOrderService, OrderService>(_ => orderService);

ListService.Users.AddRange(new List<User>
{
    new User(Guid.Parse("86eb0cc8-fc78-44cf-8a77-a0235cce4050"), "Ozodbek", "Anvarjonov", "anvafasdfsaf@gmail.com", true),
    new User(Guid.Parse("d004f04a-8ce9-4888-854c-8ccc6d77c5bd"), "Ozodbek1", "Anvarjonov", "anvafasdfsaf@gmail.com", true),
    new User(Guid.Parse("fbb6abe7-7ec0-4258-8d73-612ec8d8afc4"), "Ozodbek2", "Anvarjonov", "anvafasdfsaf@gmail.com", true),
    new User(Guid.Parse("fbb6abe7-7ec0-4258-8d73-612ec8d8afc5"), "Ozodbek3", "Anvarjonov", "anvafasdfsaf@gmail.com", false),
    new User(Guid.Parse("fbb6abe7-7ec0-4258-8d73-612ec8d8afc9"), "Ozodbek4", "Anvarjonov", "anvafasdfsaf@gmail.com", true),
});

ListService.Orders.AddRange(new List<Order>
{
    new Order(Guid.Parse("8c052ffa-a6e1-4d23-82c0-bb78adda8832"), Guid.Parse("86eb0cc8-fc78-44cf-8a77-a0235cce4050"), 12000),
    new Order(Guid.Parse("8c052ffa-a6e1-4d23-82c0-bb78adda8830"), Guid.Parse("d004f04a-8ce9-4888-854c-8ccc6d77c5bd"), 12000),
    new Order(Guid.Parse("8c052ffa-a6e1-4d23-82c0-bb78adda8839"), Guid.Parse("fbb6abe7-7ec0-4258-8d73-612ec8d8afc4"), 12000),
    new Order(Guid.Parse("8c052ffa-a6e1-4d23-82c0-bb78adda8835"), Guid.Parse("fbb6abe7-7ec0-4258-8d73-612ec8d8afc5"), 12000),
    new Order(Guid.Parse("8c052ffa-a6e1-4d23-82c0-bb78adda8833"), Guid.Parse("fbb6abe7-7ec0-4258-8d73-612ec8d8afc9"), 12000),
});

builder.Services.AddControllers();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<UserOrderService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
