using System.ComponentModel.DataAnnotations;

namespace ECommerce.Business.Users.Dto;

public class LoginDto
{
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }
}