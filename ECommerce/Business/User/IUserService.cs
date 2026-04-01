using ECommerce.Enitites.Identity;

namespace ECommerce.Business.Users;

public interface IUserService
{
    User GetById(int id);
}


/*
    بناء بيت => 
    - interface : المخطط
    - Service : العمال
    - Controller : الباب
    - DataBase : المخزن
*/