using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;
using WimabEventApp.Models;

[Route("api/events/{eventId}/invitations")]
[ApiController]
[Authorize]
public class InvitationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public InvitationsController(AppDbContext context)
    {
        _context = context;
    }

    private string? GetCurrentUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    private async Task<bool> UserOwnsEvent(int eventId, string userId)
    {
        return await _context.Events
            .AnyAsync(e => e.Id == eventId && e.UserId == userId);
    }

    // GET: api/events/{eventId}/invitations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invitation>>> GetInvitations(int eventId)
    {
        var userId = GetCurrentUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new
            {
                message = "You are not logged in."
            });
        }

        if (!await UserOwnsEvent(eventId, userId))
        {
            return NotFound(new
            {
                message = "Event not found."
            });
        }

        var invitations = await _context.Invitations
            .Where(i => i.EventId == eventId)
            .ToListAsync();

        return Ok(invitations);
    }

    // POST: api/events/{eventId}/invitations
    [HttpPost]
    public async Task<ActionResult<Invitation>> CreateInvitation(
        int eventId,
        [FromBody] Invitation invitation)
    {
        var userId = GetCurrentUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new
            {
                message = "You are not logged in."
            });
        }

        if (!await UserOwnsEvent(eventId, userId))
        {
            return NotFound(new
            {
                message = "Event not found."
            });
        }

        if (string.IsNullOrWhiteSpace(invitation.GuestName))
        {
            return BadRequest(new
            {
                message = "Guest name is required."
            });
        }

        if (string.IsNullOrWhiteSpace(invitation.GuestEmail) &&
            string.IsNullOrWhiteSpace(invitation.GuestPhoneNumber))
        {
            return BadRequest(new
            {
                message = "Guest email or phone number is required."
            });
        }

        invitation.EventId = eventId;
        invitation.Event = null;
        invitation.InviteGuid = Guid.NewGuid().ToString("N");
        invitation.IsAccepted = false;
        invitation.BringingPlusOne = false;
        invitation.IsAttended = false;

        _context.Invitations.Add(invitation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetInvitations),
            new { eventId },
            invitation);
    }

    // DELETE: api/events/{eventId}/invitations/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvitation(int eventId, int id)
    {
        var userId = GetCurrentUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new
            {
                message = "You are not logged in."
            });
        }

        if (!await UserOwnsEvent(eventId, userId))
        {
            return NotFound(new
            {
                message = "Event not found."
            });
        }

        var invitation = await _context.Invitations
            .FirstOrDefaultAsync(i => i.Id == id && i.EventId == eventId);

        if (invitation == null)
        {
            return NotFound(new
            {
                message = "Invitation not found."
            });
        }

        _context.Invitations.Remove(invitation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
