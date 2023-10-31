using N66Home.Api.Domain.Services;
using N66Home.Api.Domain.Services.Interfaces;
using N66Home.Api.Persistence.DataContext;
using N66Home.Api.Persistence.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IAuthorService, AuthorService>()
    .AddScoped<IBookService, BookService>()
    .AddScoped<SeedDataService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.

var seedService = app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedDataService>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();