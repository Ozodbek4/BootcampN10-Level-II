using N50Home.Api.Models;
using N50Home.Api.DataAccess;

namespace N50Home.Api.Services;

public class UserService
{
    public User GetById(Guid id) =>
        ListService.Users.FirstOrDefault(item => item.Id == id);

    public IEnumerable<User> Get(IEnumerable<User> users) =>
        ListService.Users.Where(item => users.Any(item => users.Any(serarchItem => 
        (serarchItem.Id == item.Id && !serarchItem.IsDeleted))));

    public User Create(User user)
    {
        ListService.Users.Add(user);

        return user;
    }

    public User Update(User user)
    {
        var updateUser = GetById(user.Id);
        
        if (updateUser == null)
            return null;

        updateUser.FirstName = user.FirstName;
        updateUser.LastName = user.LastName;
        updateUser.EmailAddress = user.EmailAddress;
        updateUser.IsDeleted = user.IsDeleted;

        return updateUser;
    }

    public User Delete(Guid id)
    {
        var deletedUser = GetById(id);

        if (deletedUser == null)
            return null;

        deletedUser.IsDeleted = true;
        
        return deletedUser;
    }
}