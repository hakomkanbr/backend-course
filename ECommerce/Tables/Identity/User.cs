namespace ECommerce.Tables.Identity;

public class User : Entity, ILog
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }

    public string Password { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }

    public ICollection<Order> Orders { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
