using ECommerce.Tables.Identity;

namespace ECommerce.Repostories.Users;

public interface IUserRepostory
{
    List<User> GetAll(User user);
    User GetById(User user);
    void Add(User user);
}
