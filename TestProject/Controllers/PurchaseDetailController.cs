using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PurchaseDetailController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [EndpointSummary("Create Purchase Detail")]
        public IActionResult PostPurchaseDetail([FromForm] PurchaseDetail purchaseDetail)
        {
            _ = _context.PurchaseDetails.Add(purchaseDetail);
            return Ok(_context.SaveChanges());
        }

        [HttpGet]
        [EndpointSummary("Get all purchase details")]
        public IActionResult GetPurchaseDetail()
        {
            List<ViPurchaseProcess> purchaseDetails = _context.ViPurchaseProcesses.ToList();
            return Ok(purchaseDetails);
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get By Purchase Detail Id")]
        public IActionResult GetPurchaseDetailById(string id)
        {
            PurchaseDetail? purchaseDetail = _context.PurchaseDetails.SingleOrDefault(x => x.PurchaseDetailId == id);
            return purchaseDetail == null ? BadRequest("Purchase Detail Not Found") : Ok(purchaseDetail);
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete Purchase Detail")]
        public IActionResult DeletePurchaseDetail(string id)
        {
            PurchaseDetail? purchaseDetail = _context.PurchaseDetails.Find(id);
            if (purchaseDetail != null)
            {
                _ = _context.PurchaseDetails.Remove(purchaseDetail);
            }

            _ = _context.SaveChanges();
            return Ok(new { message = "Purchase Detail deleted successfully" });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update Purchase Detail")]
        public IActionResult UpdatePurchaseDetail(string id, [FromForm] PurchaseDetail purchaseDt)
        {
            PurchaseDetail? purchaseDetail = _context.PurchaseDetails.Find(id);
            if (purchaseDetail != null)
            {
                purchaseDetail.PurchaseId = purchaseDt.PurchaseId;
                purchaseDetail.ProductId = purchaseDt.ProductId;
                purchaseDetail.Quantity = purchaseDt.Quantity;
                purchaseDetail.Amount = purchaseDt.Amount;
                _ = _context.SaveChanges();
            }
            return Ok(new { message = "Purchase Detail updated successfully" });
        }
    }
}
