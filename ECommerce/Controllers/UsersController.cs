using Microsoft.AspNetCore.Mvc;
using ECommerce.Business.Users.Dto;
using ECommerce.Business.Users.Services;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Controllers;

// FluentValidation

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService _userService) : Controller
{

    #region Account
    [HttpPost("[Action]")]
    public IActionResult Login(LoginDto dto)
    {
        if(dto.Email == "admin@test.com" && dto.Password == "Admin.123")
        {
            // User Has Access To System
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,dto.Email),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ghsduifghdfiuoghdfuighduighduijgiorjierhsguiohioawefjgviopgkiorwjgoiwergsjosijggaewrgegkwapogkeprohjeroptgjwropigjeriohgjerosihjestkogmbdfsk"));

            var token = new JwtSecurityToken(
                claims : claims,
                expires : DateTime.Now.AddHours(1),
                signingCredentials : new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(tokenString);
        }
        else
        {
            return StatusCode(400 , "User Email And Password Is Wrong");
        }
    }
    #endregion

    #region Users
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(_userService.GetById(id));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateUserDto userdto)
    {
        if (userdto.Name.Length < 3) return StatusCode(400, "Name should be > 3");

        _userService.Create(userdto);
        return Ok();
    }
    #endregion User
}
