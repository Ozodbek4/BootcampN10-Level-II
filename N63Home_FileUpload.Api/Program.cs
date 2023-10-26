using Microsoft.AspNetCore.Authentication.JwtBearer;
using N63Home_FileUpload.Api.Services;
using Microsoft.IdentityModel.Tokens;
using N63Home_FileUpload.Api.Settings;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

builder.Services.AddControllers();
builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<TokenGeneratorService>();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.RequireHttpsMetadata = false;

        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtSettings.ValidateIssuer,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidateAudience = jwtSettings.ValidateAudience,
            ValidAudience = jwtSettings.ValidAudience,
            ValidateLifetime = jwtSettings.ValidateLifetime,
            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
        };
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();