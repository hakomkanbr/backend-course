namespace ECommerce.Enitites.Customer;

public class Cart : Entity
{
    public bool Status { get; set; }

    public ICollection<CartItems> CartItems { get; set; }
}
