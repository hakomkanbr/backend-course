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


public class RegisterDto
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }
}
