using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;
using WimabEventApp.Models;

[Route("api/[controller]")]
[ApiController]
public class GuestsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GuestsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetGuests()
    {
        var guests = await _context.Guests.ToListAsync();
        return Ok(guests);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitRsvp([FromBody] Guest newGuest)
    {
        if (string.IsNullOrEmpty(newGuest.Name) || string.IsNullOrEmpty(newGuest.Surname))
            return BadRequest("Name and Surname are required.");

        // Generate a ticket code if not provided
        if (string.IsNullOrEmpty(newGuest.TicketCode))
        {
            newGuest.TicketCode = $"WIMAB-{newGuest.Name.ToUpper()}-{new Random().Next(1000, 9999)}";
        }

        _context.Guests.Add(newGuest);
        await _context.SaveChangesAsync();
        
        return Ok(new { message = "RSVP submitted successfully!", ticketCode = newGuest.TicketCode });
    }
}