using N53Home1.Models;

namespace N53Home1.Services.Interfaces;

internal interface INotificationService
{
    ValueTask SenderOrderMessageAsnyc(IEnumerable<User> usersId);

    ValueTask SenderBonusMessageAsync(IEnumerable<User> usersId);
}