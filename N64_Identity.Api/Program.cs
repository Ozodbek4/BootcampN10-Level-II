using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using N64_Identity.Api.Configurations;
using N64_Identity.Application.Common.Settings;
using N64_Identity.Infrastructure.Common.Identity.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

//builder.Services.AddScoped<AuthService>();
//builder.Services.AddTransient<TokenGeneratorService>();
//builder.Services.AddControllers();

//var jwtSettings = new JwtSettings();
//builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

//// authentication scheme - autentikatsiya qilish usuli
//builder
//    .Services
//    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.RequireHttpsMetadata = false;

//        options.TokenValidationParameters = new TokenValidationParameters()
//        {
//            ValidateIssuer = jwtSettings.ValidateIssuer,
//            ValidIssuer = jwtSettings.ValidIssuer,
//            ValidateAudience = jwtSettings.ValidateAudience,
//            ValidAudience = jwtSettings.ValidAudience,
//            ValidateLifetime = jwtSettings.ValidateLifetime,
//            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
//        };
//    });

await builder.ConfigureAsync();

var app = builder.Build();

await app.ConfigureAsync();
//app.MapControllers();
//app.UseAuthentication();
//app.UseAuthorization();

app.Run();