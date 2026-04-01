using ECommerce.Repostories.Users;
using ECommerce.Enitites.Identity;

namespace ECommerce.Business.Users;

public class UserService(IUserRepostory _userRepo) : IUserService
{
    private int count {  get; set; }

    public void Plus()
    {
        count++;
    }

    public void Minus()
    {
        count--;
    }

    public int Print()
    {
        return count;
    }

    public User GetById(int id)
    {
        return _userRepo.GetById(id);
    }
}
