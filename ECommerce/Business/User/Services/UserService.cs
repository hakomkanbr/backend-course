using ECommerce.Repostories.Users;
using ECommerce.Enitites.Identity;
using ECommerce.Business.Users.Dto;

namespace ECommerce.Business.Users.Services;

public class UserService(IUserRepostory _userRepo) : IUserService
{
    public void Create(CreateUserDto userDto)
    {
        User user = new User
        {
            CreatedAt = DateTime.Now,
            Email = userDto.Email,
            FullName = userDto.Name,
            PasswordHash = userDto.Password,
            PhoneNumber = userDto.Phone,
            UserName = userDto.UserName,
        };

        _userRepo.Add(user);
    }

    public GetUserDto GetById(int id)
    {

        User entity = _userRepo.GetById(id);

        GetUserDto userDto = new GetUserDto
        {
            Name = entity.FullName,
            Email = entity.Email,
            //RoleName = entity.Role?.Name,
            Phone = entity.PhoneNumber,
            UserName = entity.UserName
        };

        return userDto;
    }
}

//public interface IMyService
//{
//    Guid Id { get; }
//}

//public class MyService : IMyService
//{
//    public Guid Id { get; } = Guid.NewGuid();
//}