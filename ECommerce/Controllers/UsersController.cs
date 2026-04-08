using Microsoft.AspNetCore.Mvc;
using ECommerce.Business.Users.Dto;
using ECommerce.Business.Users.Services;

namespace ECommerce.Controllers;

// FluentValidation

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService _userService) : Controller
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(_userService.GetById(id));
    }


    // 
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto userdto)
    {
        if (userdto.Name.Length < 3) return StatusCode(400, "Name should be > 3");

        _userService.Create(userdto);
        return Ok();
    }

    //private async Task<List<User>> GetUsersAsync()
    //{
    //    var users = _context.Users.ToList();
    //    return users;
    //}
}
