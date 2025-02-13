using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromForm] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get By Product Id")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.ProductId == id);

            if (product == null)
            {
                return BadRequest("Product Not Found");
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete Product")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [EndpointSummary("Update Product")]
        public async Task<IActionResult> UpdateProduct(string id, string newProduct)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            if (product != null)
            {
                product.ProductName = newProduct;
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
