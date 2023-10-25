var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Use(async (ContextCallback, next) =>
{
    var massage = $"{DateTimeOffset.Now} {ContextCallback.Request.Body}";
    await using var filestream = File.Open("log.txt", FileMode.Append, FileAccess.Write);
    await using var file = new StreamWriter(filestream);
    await file.WriteAsync(massage);
    await next();
});


// app.UseSwagger();
// app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.MapGet("/", () => { });

// app.MapControllers();

app.Run();