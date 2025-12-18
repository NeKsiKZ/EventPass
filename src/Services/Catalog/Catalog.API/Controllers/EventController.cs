using Catalog.API.Data;
using Catalog.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public EventController(CatalogDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }

        // GET: api/v1/event/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(Guid id)
        {
            var evt = await _context.Events.FindAsync(id);
            if (evt == null)
            {
                return NotFound();
            }
            return Ok(evt);
        }

        // POST: api/v1/event
        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(Event eventItem)
        {
            _context.Events.Add(eventItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventById), new { id = eventItem.Id }, eventItem);
        }
    }
}