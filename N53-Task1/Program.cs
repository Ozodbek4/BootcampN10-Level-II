using Microsoft.Extensions.DependencyInjection;
using N53Home1.Data;
using N53Home1.Events;
using N53Home1.Services;
using N53Home1.Services.Interfaces;

var baseController = new ServiceCollection();

baseController
    .AddSingleton<UserBonusService>()
    .AddSingleton<UserPromotionService>()
    .AddScoped<INotificationService, EmailSenderService>()
    .AddScoped<INotificationService, SmsSenderService>()
    .AddScoped<INotificationService, TelegramSenderService>()
    .AddScoped<BonusAchievedEvent>()
    .AddScoped<OrderCreatedEvent>();

var app = baseController.BuildServiceProvider();

var email = app.GetRequiredService<EmailSenderService>();
var bonusEvent = app.GetRequiredService<BonusAchievedEvent>;
var orderPromotionEvent = app.GetRequiredService<OrderCreatedEvent>();
var sms =  app.GetRequiredService<SmsSenderService>();
var tg = app.GetRequiredService<TelegramSenderService>();
var bonus = app.CreateScope().ServiceProvider.GetRequiredService<UserBonusService>();
var promotion = app.CreateScope().ServiceProvider.GetRequiredService<UserPromotionService>();

await bonus.Create(UsersList.Users);