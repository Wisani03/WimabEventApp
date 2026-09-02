using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;
using WimabEventApp.Models;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new
            {
                message = "You are not logged in."
            });
        }

        var events = await _context.Events
            .Where(e => e.UserId == userId)
            .Include(e => e.WishlistItems)
            .Include(e => e.Invitations)
            .ToListAsync();

        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new
            {
                message = "You are not logged in."
            });
        }

        var eventItem = await _context.Events
            .Where(e => e.Id == id && e.UserId == userId)
            .Include(e => e.WishlistItems)
            .Include(e => e.Invitations)
            .FirstOrDefaultAsync();

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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new
            {
                message = "You are not logged in."
            });
        }

        if (string.IsNullOrWhiteSpace(newEvent.Title))
        {
            return BadRequest(new
            {
                message = "Event title is required."
            });
        }

        newEvent.UserId = userId;

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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new
            {
                message = "You are not logged in."
            });
        }

        var eventItem = await _context.Events
            .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);

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
