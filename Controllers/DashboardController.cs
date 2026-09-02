using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetDashboard()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new
            {
                message = "You are not logged in."
            });
        }

        var userEvents = await _context.Events
            .Where(e => e.UserId == userId)
            .Select(e => new
            {
                e.Id,
                e.Title,
                e.Category,
                e.VenueLocation,
                e.EventDate
            })
            .ToListAsync();

        var eventIds = userEvents
            .Select(e => e.Id)
            .ToList();

        var guestCount = eventIds.Count == 0
            ? 0
            : await _context.Set<WimabEventApp.Models.Guest>()
                .CountAsync(g => eventIds.Contains(g.EventId));

        var invitationCount = eventIds.Count == 0
            ? 0
            : await _context.Invitations
                .CountAsync(i => eventIds.Contains(i.EventId));

        var wishlistCount = eventIds.Count == 0
            ? 0
            : await _context.WishlistItems
                .CountAsync(w => eventIds.Contains(w.EventId));

        var recentEvents = userEvents
            .OrderByDescending(e => e.EventDate)
            .Take(3)
            .Select(e => new
            {
                e.Id,
                e.Title,
                e.Category,
                e.VenueLocation,
                e.EventDate
            })
            .ToList();

        var recentInvitations = eventIds.Count == 0
            ? new List<object>()
            : await _context.Invitations
                .Where(i => eventIds.Contains(i.EventId))
                .Include(i => i.Event)
                .OrderByDescending(i => i.Id)
                .Take(3)
                .Select(i => new
                {
                    i.Id,
                    i.GuestName,
                    i.IsAccepted,
                    i.BringingPlusOne,
                    EventTitle = i.Event!.Title
                })
                .Cast<object>()
                .ToListAsync();

        return Ok(new
        {
            totalEvents = userEvents.Count,
            totalGuests = guestCount,
            totalInvitations = invitationCount,
            totalWishlistItems = wishlistCount,
            recentEvents,
            recentInvitations
        });
    }
}
