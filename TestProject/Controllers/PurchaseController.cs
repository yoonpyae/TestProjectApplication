using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PurchaseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [EndpointSummary("Create Purchase")]
        public IActionResult PostPurchase([FromForm] Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            return Ok(_context.SaveChanges());
        }

        [HttpGet]
        [EndpointSummary("Get all purchases")]
        public IActionResult GetPurchases()
        {
            var purchases = _context.Purchases.ToList();
            return Ok(purchases);
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get By Purchase Id")]
        public IActionResult GetPurchaseById(string id)
        {
            var purchase = _context.Purchases.SingleOrDefault(x => x.PurchaseId == id);
            if (purchase == null)
            {
                return BadRequest("Purchase Not Found");
            }
            return Ok(purchase);
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete Purchase")]
        public IActionResult DeletePurchase(string id)
        {
            var purchase = _context.Purchases.Find(id);

            if (purchase == null)
            {
                return BadRequest("Purchase Not Found");
            }

            var purchasedetails = _context.PurchaseDetails.Where(x => x.PurchaseId == id).ToList();

            if (purchasedetails.Any())
            {
                return BadRequest("Purchase Details are associated with this Purchase");
            }
            else
            {
                if (purchase != null)
                {
                    _context.Purchases.Remove(purchase);
                    _context.SaveChanges();
                    return Ok(new { message = "Purchase deleted successfully" });
                }
                return BadRequest("Purchase Not Found");
            }
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update Purchase")]
        public IActionResult UpdatePurchase(string id, [FromForm] Purchase purchases)
        {
            var purchase = _context.Purchases.Find(id);
            if (purchase != null)
            {
                purchase.PurchaseId = purchases.PurchaseId;
                purchase.PurchaseDate = purchases.PurchaseDate;
                _context.Purchases.Update(purchase);
                _context.SaveChanges();
                return Ok(new { message = "Purchase updated successfully" });
            }
            return BadRequest("Purchase Not Found");
        }
    }
}
