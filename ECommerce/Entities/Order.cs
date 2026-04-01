using ECommerce.Enitites.Identity;

namespace ECommerce.Enitites;

public class Order : Entity, ILog
{
    public string Code { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public ICollection<OrderItems> OrderItems { get; set; }
}
