using ECommerce.Tables.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;


[ApiController]
[Route("[controller]")]
public class UsersController : Controller
{
    public readonly AppDbContext _context;
    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await GetUsersAsync());
    }

    [HttpGet()]
    public async Task<IActionResult> GetUsersList()
    {
        return Ok(await GetUsersAsync());
    }

    private async Task<List<User>> GetUsersAsync()
    {
        var users = _context.Users.ToList();
        return users;
    }
}
