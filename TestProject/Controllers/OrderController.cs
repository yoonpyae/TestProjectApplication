using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [EndpointSummary("Create Order")]
        public IActionResult PostOrders([FromForm] Order orders)
        {
            _ = _context.Orders.Add(orders);
            return Ok(_context.SaveChanges());
        }

        [HttpGet]
        [EndpointSummary("Get all orders")]
        public IActionResult GetOrders()
        {
            List<Order> orders = _context.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get By Order Id")]
        public IActionResult GetOrderById(string id)
        {
            Order? order = _context.Orders.SingleOrDefault(x => x.OrderId == id);
            return order == null ? BadRequest("Order Not Found") : Ok(order);
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete Order")]
        public IActionResult DeleteOrder(string id)
        {
            Order? order = _context.Orders.Find(id);
            if (order != null)
            {
                _ = _context.Orders.Remove(order);
            }

            _ = _context.SaveChanges();
            return Ok(new { message = "Order deleted successfully" });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update Order")]
        public IActionResult UpdateOrder(string id, [FromForm] Order orders)
        {
            Order? order = _context.Orders.Find(id);
            if (order != null)
            {
                order.OrderId = orders.OrderId;
                order.CustomerId = orders.CustomerId;
                order.ProductId = orders.ProductId;
                order.Quantity = orders.Quantity;
                order.OrderDate = orders.OrderDate;
                order.TotalAmount = orders.TotalAmount;
                _ = _context.Orders.Update(order);
                _ = _context.SaveChanges();
                return Ok(new { message = "Order updated successfully" });
            }
            return BadRequest("Order Not Found");
        }
    }
}
