namespace ECommerce.Tables;

public abstract class Entity
{
    public int Id { get; set; }
}

public interface ILog
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}

public class User : Entity, ILog
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }


    public ICollection<Order> Orders { get; set; }
    public DateTime CreatedAt { get ; set; }
    public DateTime UpdateAt { get; set; }
}

public class Cart : Entity
{
    public bool Status { get; set; }

    public ICollection<CartItems> CartItems { get; set; }
}

public class CartItems : Entity, ILog
{
    public int CartId { get; set; }
    public Cart Cart { get; set; }

    public int Price { get; set; }
    public int Quantity { get; set; }


    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}

public class Role : Entity
{
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }
}

public class Order : Entity, ILog
{
    public string Code { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}