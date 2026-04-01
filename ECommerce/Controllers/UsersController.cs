using ECommerce.Business.Users;
using ECommerce.Repostories.Users;
using ECommerce.Enitites.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;


[ApiController]
[Route("[controller]")]
public class UsersController(UserService _userService) : Controller
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(_userService.GetById(id));
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> plus()
    {
        _userService.Plus();
        return Ok();
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Minus()
    {
        _userService.Minus();
        return Ok();
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Print()
    {
        return Ok(_userService.Print());
    }

    //[HttpGet()]
    //public async Task<IActionResult> GetUsers()
    //{
    //    return Ok(await GetUsersAsync());
    //}

    //[HttpGet()]
    //public async Task<IActionResult> GetUsersList()
    //{
    //    return Ok(await GetUsersAsync());
    //}



    //private async Task<List<User>> GetUsersAsync()
    //{
    //    var users = _context.Users.ToList();
    //    return users;
    //}
}
