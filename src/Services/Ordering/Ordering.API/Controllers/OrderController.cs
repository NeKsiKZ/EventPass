using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;
using Ordering.Infrastructure.Persistence;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;
        }

        // GET: api/v1/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _context.Orders.ToListAsync());
        }

        // POST: api/v1/Order
        [HttpPost]
        public async Task<ActionResult<Guid>> CheckoutOrder([FromBody] CheckoutRequest request)
        {
            var newOrder = new Order(
                userId: Guid.NewGuid(),
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.EmailAddress,
                address: request.AddressLine,
                country: request.Country,
                zipCode: request.ZipCode,
                totalPrice: request.TotalPrice
            );

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return Ok(newOrder.Id);
        }
    }

    public class CheckoutRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public decimal TotalPrice { get; set; }
    }
}