using Catalog.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")] // URL: api/v1/event
    public class EventController : ControllerBase
    {
        private static readonly List<Event> _events = new List<Event>
        {
            new Event
            {
                Id = Guid.NewGuid(),
                Name = "Metallica: World Tour",
                Date = DateTime.Now.AddMonths(2),
                Description = "The metal legend returns! An unforgettable show.",
                Venue = "National Stadium, Warsaw",
                Price = 350.00m,
                ImageUrl = "https://placeholder.com/metallica.png"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Name = "Jazz Festival 2025",
                Date = DateTime.Now.AddMonths(1),
                Description = "The best jazz musicians in one place.",
                Venue = "Stodola Club, Warsaw",
                Price = 80.50m,
                ImageUrl = "https://placeholder.com/jazz.png"
            }
        };

        // GET: api/v1/event
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Event>), 200)]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            return Ok(_events);
        }

        // GET: api/v1/event/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Event), 200)]
        [ProducesResponseType(404)]
        public ActionResult<Event> GetEventById(Guid id)
        {
            var evt = _events.FirstOrDefault(e => e.Id == id);
            if (evt == null)
            {
                return NotFound();
            }
            return Ok(evt);
        }
    }
}