using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Tables.Products;

public class Product : Entity
{
    public string Name { get; set; }

    public string Price { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool? IsDeleted { get; set; }
}

