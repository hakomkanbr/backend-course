using ECommerce.Tables.Identity;

namespace ECommerce.Repostories.Users;

public class UserRepostory : IUserRepostory
{
    public readonly AppDbContext _context;
    public UserRepostory(AppDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public List<User> GetAll(User user)
    {
        var users = _context.Users.ToList();
        return users;
    }

    public User GetById(User user)
    {
        throw new NotImplementedException();
    }
}