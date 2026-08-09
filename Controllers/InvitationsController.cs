using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;
using WimabEventApp.Models;

[Route("api/events/{eventId}/invitations")]
[ApiController]
public class InvitationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public InvitationsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/events/{eventId}/invitations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invitation>>> GetInvitations(int eventId)
    {
        var invitations = await _context.Invitations
            .Where(i => i.EventId == eventId)
            .ToListAsync();

        return Ok(invitations);
    }

    // POST: api/events/{eventId}/invitations
    [HttpPost]
    public async Task<ActionResult<Invitation>> CreateInvitation(int eventId, [FromBody] Invitation invitation)
    {
        var eventExists = await _context.Events.AnyAsync(e => e.Id == eventId);
        if (!eventExists)
        {
            return NotFound(new { message = "Event not found." });
        }

        invitation.EventId = eventId;
        invitation.Event = null; // Prevent cycle validation issues on insert

        if (string.IsNullOrEmpty(invitation.InviteGuid))
        {
            invitation.InviteGuid = Guid.NewGuid().ToString();
        }

        _context.Invitations.Add(invitation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInvitations), new { eventId = eventId }, invitation);
    }

    // DELETE: api/events/{eventId}/invitations/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvitation(int eventId, int id)
    {
        var invitation = await _context.Invitations
            .FirstOrDefaultAsync(i => i.Id == id && i.EventId == eventId);

        if (invitation == null)
        {
            return NotFound(new { message = "Invitation not found." });
        }

        _context.Invitations.Remove(invitation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}