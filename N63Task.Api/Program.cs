using N63Task.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<CultureMiddleware>();

app.MapGet("/", () => DateTime.Now.ToString());

app.Run();