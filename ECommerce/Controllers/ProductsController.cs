using ECommerce.Repostories;
using ECommerce.Tables.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : Controller
{

    // Controller => Database
    // Controller => Service (optional) => Repostory (optional) => AppDbContext

    // Layar Pattern => Vertical
    // Onion Pattern , MicroService , Clean Structure => horizantal

    public readonly IGenericRepostory<Product> _productRepostory;
    public ProductsController(IGenericRepostory<Product> productRepostory)
    {
        _productRepostory = productRepostory;
    }


    [HttpPost]
    public async Task<IActionResult> Create(Product dto) {
        _productRepostory.Create(dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_productRepostory.GetAll());
    }

    [HttpPut]
    public async Task<IActionResult> Update(int productId,Product product)
    {
        _productRepostory.Update(productId, product);
        return Ok();
    }
}
