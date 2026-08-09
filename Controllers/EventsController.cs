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

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] Event newEvent)
    {
        if (string.IsNullOrEmpty(newEvent.Title) || string.IsNullOrEmpty(newEvent.UserId))
            return BadRequest("Title and UserId are required.");

        _context.Events.Add(newEvent);
        await _context.SaveChangesAsync();
        
        return Ok(new { message = "Event created successfully!", eventId = newEvent.Id });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var ev = await _context.Events.FindAsync(id);
        if (ev == null) return NotFound("Event not found.");

        _context.Events.Remove(ev);
        await _context.SaveChangesAsync();
        
        return Ok(new { message = "Event deleted successfully!" });
    }
}