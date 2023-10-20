//N52 - HT1
//- dasturda user qo'shilgan payti userga email jo'natish kerak
//- buni user yoki email service ichida qilish mumkinmas
//- buning uchun user foundations service, email sender service va account orchestration service dan foydalaning
//- bunda o'rtada eventlarni ushlab turuchi AccountEventStore modeli ham bo'lsin
//- userlar qo'shilganda shu event store orqali OnUserCreated event chaqirilsin
//- AccountNotificationService da esa shu event uchun handler yozing
//- bu handler Email Sender service dan foydalanib, userga welcome email jo'natsin
using Microsoft.Extensions.DependencyInjection;
using N52Home1.Models;
using N52Home1.Services;



var baseService = new ServiceCollection();
baseService.AddScoped<UserService>()
    .AddScoped<UserFoundationService>()
    .AddSingleton<AccountNotificationService>()
    .AddSingleton<AccountEventStore>();

var app = baseService.BuildServiceProvider();

var service = app.GetRequiredService<AccountNotificationService>();
var userFoundationService = app.CreateScope().ServiceProvider.GetRequiredService<UserFoundationService>();
var @event = app.GetRequiredService<AccountEventStore>();
await userFoundationService.Create(new User { FirstName = "asdasd" });

