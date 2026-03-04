namespace ECommerce.Tables.Products;

/**
 * Product Has One Category
 * Category Include More Products
 * => One To Many
 */

public class Category : Entity
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}
