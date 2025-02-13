using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SupplierController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [EndpointSummary("Create Supplier")]
        public IActionResult PostSupplier([FromForm] Supplier supplier)
        {
            _ = _context.Suppliers.Add(supplier);
            _ = _context.SaveChanges();
            return Ok(new { message = "Supplier created successfully" });
        }

        [HttpGet]
        [EndpointSummary("Get all suppliers")]
        public IActionResult GetSuppliers()
        {
            List<Supplier> suppliers = _context.Suppliers.ToList();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get By Supplier Id")]
        public IActionResult GetSupplierById(string id)
        {
            Supplier? supplier = _context.Suppliers.SingleOrDefault(x => x.SupplierId == id);
            return supplier == null ? BadRequest("Supplier Not Found") : Ok(supplier);
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete Supplier")]
        public IActionResult DeleteSupplier(string id)
        {
            Supplier? supplier = _context.Suppliers.Find(id);
            if (supplier != null)
            {
                _ = _context.Suppliers.Remove(supplier);
            }

            _ = _context.SaveChanges();
            return Ok(new { message = "Supplier deleted successfully" });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update Supplier")]
        public IActionResult UpdateSupplier(string id, [FromForm] Supplier supplier)
        {
            Supplier? supplierToUpdate = _context.Suppliers.Find(id);
            if (supplierToUpdate == null)
            {
                return BadRequest("Supplier Not Found");
            }
            supplierToUpdate.SupplierName = supplier.SupplierName;
            supplierToUpdate.Address = supplier.Address;
            supplierToUpdate.PhoneNo = supplier.PhoneNo;
            _ = _context.SaveChanges();
            return Ok(new { message = "Supplier updated successfully" });
        }
    }
}
