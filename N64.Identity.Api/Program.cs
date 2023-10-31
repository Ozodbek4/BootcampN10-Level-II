using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Infrastructure.Common.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IAuthService, AuthService>()
    .AddScoped<ITokenGenerateService, TokenGeneratorService>();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();