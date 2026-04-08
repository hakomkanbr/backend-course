using ECommerce.Enitites.Identity;
using ECommerce.Enitites;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Business.Users.Dto;

public class CreateUserDto
{
    [Required]
    [MinLength(3)]
    public string UserName { get; set; }

    public string Name { get; set; }


    [EmailAddress]
    public string Email { get; set; }
    public string? Phone { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    public int? RoleId { get; set; }
}
