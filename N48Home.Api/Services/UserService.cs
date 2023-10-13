using N48Home.Api.DataAccess;
using N48Home.Api.Models;

namespace N48Home.Api.Services;

public class UserService
{
    private readonly IDataContext _appDataContext;
    public UserService(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<User> CreateAsync(User user)
    {
        await _appDataContext.Users.AddAsync(user);

        await _appDataContext.Users.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> DeleteAsync(Guid id)
    {
        var deletedUser = await GetByIdAsync(id);

        if (deletedUser is null)
            return null;

        deletedUser.IsDeleted = true;

        await _appDataContext.Users.SaveChangesAsync();

        return deletedUser;


    }

    public ValueTask<IEnumerable<User>> GetAsync() =>
        new ValueTask<IEnumerable<User>>(GetUndeletedUsers());

    public ValueTask<User> GetByIdAsync(Guid id) =>
       new ValueTask<User>(_appDataContext.Users.FirstOrDefault(us => us.Id == id));

    public async ValueTask<User> UpdateAsync(User user)
    {
        var updatedUser = await GetByIdAsync(user.Id);

        if (user is null)
            return null;

        updatedUser.FirstName = user.FirstName;
        updatedUser.LastName = user.LastName;

        await _appDataContext.Users.SaveChangesAsync();

        return updatedUser;
    }
    private IQueryable<User> GetUndeletedUsers() =>
        _appDataContext.Users.Where(user => !user.IsDeleted).AsQueryable();
}