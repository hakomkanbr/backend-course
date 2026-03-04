namespace ECommerce.Tables.Customer;

public class CartItems : Entity, ILog
{
    public int CartId { get; set; }
    public Cart Cart { get; set; }

    public int Price { get; set; }
    public int Quantity { get; set; }


    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
