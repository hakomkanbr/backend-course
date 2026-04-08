using ECommerce.Business.Users.Dto;
using ECommerce.Enitites.Identity;

namespace ECommerce.Business.Users.Services;

public interface IUserService
{
    GetUserDto GetById(int id);
    void Create(CreateUserDto userDto);
}


/*
    بناء بيت => 
    - interface : المخطط
    - Service : العمال
    - Controller : الباب
    - DataBase : المخزن
*/