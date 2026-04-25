using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerce.Business.Users.Dto;
using ECommerce.Business.Users.Services;

namespace ECommerce.Controllers;

[ApiController]
[Route("[controller]")]

public class UsersController : ControllerBase  
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Policy = "CanManagerUser")] // Claim Based
    public async Task<IActionResult> GetAll()
    {
        //var users = await _userService.GetAll();
        return Ok();
    }


    [HttpPost]
    [Authorize(Policy = "CanCreateUser")] // Claim Based

    public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
    {
        //if (!ModelState.IsValid)
        //    return BadRequest(ModelState);

        //await _userService.Create(dto);

        //if (!result)
        //    return BadRequest(new { message = "فشل إنشاء المستخدم" });

        return Ok(new { message = "تم إنشاء المستخدم بنجاح" });
    }
}