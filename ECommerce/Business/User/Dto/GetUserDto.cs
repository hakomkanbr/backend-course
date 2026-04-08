namespace ECommerce.Business.Users.Dto;

public class GetUserDto
{
    public string UserName { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }
    public string? Phone { get; set; }

    public string RoleName { get; set; }
}