using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.ClassModels;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EndpointSummary("Get all customers")]
        [EndpointDescription("Get all customers")]

        public IActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult PostCustomers([FromForm] Customer customer)
        {
            _context.Customers.Add(customer);
            return Ok(_context.SaveChanges());
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get By Customer Id")]
        public IActionResult GetCustomerById(string id)
        {
            var customer = _context.Customers.SingleOrDefault(y => y.CustomerId == id);
            if (customer == null)
            {
                return BadRequest("Customer Not Found");
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete Customer")]
        public IActionResult DeleteCustomer(string id)
        {
            var customer = _context.Customers.Find(id);

            if (customer != null)
                _context.Customers.Remove(customer);

            return Ok(_context.SaveChanges());
        }


        [HttpPut]
        [EndpointSummary("Update Customer")]
        public IActionResult UpdateCustomer(string id, string newCustomer)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);

            if (customer is not null)
            {
                customer.CustomerName = newCustomer;
            }

            return Ok(_context.SaveChanges());
        }

        [HttpGet("by-customer-order")]
        [EndpointSummary("Get all customers with order")]
        public IActionResult GeyByCustomerOrder(string CustomerID)
        {
            var customers = from cus in _context.Customers
                            join order in _context.Orders
                            on cus.CustomerId equals order.CustomerId
                            join product in _context.Products
                            on order.ProductId equals product.ProductId
                            select new  {
                                orderId = order.OrderId,
                                customerName = cus.CustomerName,
                                productName = product.ProductName,
                            };

            var customerOrder = customers.ToList();
            return Ok(customerOrder);
        }


        [HttpGet("total-orders/{customerId}")]
        [EndpointSummary("Get total orders by customer")]
        public IActionResult GetTotalOrdersByCustomer(string customerId)
        {
            var totalOrders = _context.Orders.Count(o => o.CustomerId == customerId);
            return Ok(totalOrders);
        }

        [HttpGet("total-amount/{customerId}")]
        [EndpointSummary("Get total amount by customer")]
        public IActionResult GetTotalAmountByCustomer(string customerId)
        {
            var totalAmount = _context.Orders.Where(o => o.CustomerId == customerId).Sum(o => o.TotalAmount);
            return Ok(totalAmount);
        }
    }
}
