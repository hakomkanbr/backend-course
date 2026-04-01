using ECommerce.Enitites.Products;

namespace ECommerce.Enitites;

public class OrderItems : Entity
{
    public string Code { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }


    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int Quantity { get; set; }
}