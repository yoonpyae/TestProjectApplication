using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EndpointSummary("Get all products")]
        [EndpointDescription("Get all products")]
        public async Task<IActionResult> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromForm] Product product)
        {
            _ = _context.Products.Add(product);
            _ = await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get By Product Id")]
        public async Task<IActionResult> GetProductById(string id)
        {
            Product? product = await _context.Products.SingleOrDefaultAsync(x => x.ProductId == id);

            return product == null ? BadRequest("Product Not Found") : Ok(product);
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete Product")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _ = _context.Products.Remove(product);
                _ = await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [EndpointSummary("Update Product")]
        public async Task<IActionResult> UpdateProduct(string id, string newProduct)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            if (product != null)
            {
                product.ProductName = newProduct;
                _ = await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
