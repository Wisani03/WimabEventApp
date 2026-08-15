using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;
using WimabEventApp.Models;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        var events = await _context.Events
            .Include(e => e.WishlistItems)
            .Include(e => e.Invitations)
            .ToListAsync();

        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        var eventItem = await _context.Events
            .Include(e => e.WishlistItems)
            .Include(e => e.Invitations)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (eventItem == null)
        {
            return NotFound(new
            {
                message = "Event not found."
            });
        }

        return Ok(eventItem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] Event newEvent)
    {
        if (string.IsNullOrWhiteSpace(newEvent.Title))
        {
            return BadRequest(new
            {
                message = "Event title is required."
            });
        }

        if (string.IsNullOrWhiteSpace(newEvent.UserId))
        {
            return BadRequest(new
            {
                message = "User ID is required."
            });
        }

        _context.Events.Add(newEvent);

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Event created successfully!",
            eventId = newEvent.Id
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);

        if (eventItem == null)
        {
            return NotFound(new
            {
                message = "Event not found."
            });
        }

        _context.Events.Remove(eventItem);

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Event deleted successfully!"
        });
    }
}