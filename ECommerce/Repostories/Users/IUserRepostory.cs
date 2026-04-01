using ECommerce.Enitites.Identity;

namespace ECommerce.Repostories.Users;

public interface IUserRepostory
{
    List<User> GetAll(User user);
    User GetById(int id);
    void Add(User user);
}