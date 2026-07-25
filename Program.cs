using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;
using WimabEventApp.Models;

var builder = WebApplication.CreateBuilder(args);

// SQLite database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=wimab_event.db"));

var app = builder.Build();

app.UseDefaultFiles(); 
app.UseStaticFiles();

// Ensure database is created on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); 
}

// ==========================================
// EVENTS ENDPOINTS
// ==========================================

// Get all events
app.MapGet("/api/events", async (AppDbContext db) => 
    await db.Events.Include(e => e.WishlistItems).Include(e => e.Invitations).ToListAsync());

// Create a new event
app.MapPost("/api/events", async (Event newEvent, AppDbContext db) =>
{
    if (string.IsNullOrEmpty(newEvent.Title) || string.IsNullOrEmpty(newEvent.UserId))
        return Results.BadRequest("Title and UserId are required.");

    db.Events.Add(newEvent);
    await db.SaveChangesAsync();
    
    return Results.Ok(new { message = "Event created successfully!", eventId = newEvent.Id });
});

// ==========================================
// WISHLIST ENDPOINTS (Per Event)
// ==========================================

// Get wishlist items for a specific event
app.MapGet("/api/events/{eventId}/wishlist", async (int eventId, AppDbContext db) =>
{
    var items = await db.WishlistItems.Where(w => w.EventId == eventId).ToListAsync();
    return Results.Ok(items);
});

// Add a wishlist item to an event
app.MapPost("/api/events/{eventId}/wishlist", async (int eventId, WishlistItem item, AppDbContext db) =>
{
    var eventExists = await db.Events.AnyAsync(e => e.Id == eventId);
    if (!eventExists) return Results.NotFound("Event not found.");

    item.EventId = eventId;
    item.IsClaimed = false;
    
    db.WishlistItems.Add(item);
    await db.SaveChangesAsync();
    
    return Results.Ok(new { message = "Wishlist item added successfully!" });
});

// Claim a wishlist item
app.MapPost("/api/wishlist/claim/{id}", async (int id, ClaimRequest request, AppDbContext db) =>
{
    var item = await db.WishlistItems.FindAsync(id);
    if (item == null) return Results.NotFound("Gift not found.");

    item.IsClaimed = true;
    item.ClaimedByGuestName = request.GuestName;
    await db.SaveChangesAsync();

    return Results.Ok(new { message = "Gift claimed successfully!" });
});

// ==========================================
// INVITATION / RSVP ENDPOINTS (Per Event)
// ==========================================

// Get invitations for an event
app.MapGet("/api/events/{eventId}/invitations", async (int eventId, AppDbContext db) =>
{
    var invitations = await db.Invitations.Where(i => i.EventId == eventId).ToListAsync();
    return Results.Ok(invitations);
});

// Create an invitation
app.MapPost("/api/events/{eventId}/invitations", async (int eventId, Invitation invitation, AppDbContext db) =>
{
    var eventExists = await db.Events.AnyAsync(e => e.Id == eventId);
    if (!eventExists) return Results.NotFound("Event not found.");

    invitation.EventId = eventId;
    invitation.InviteGuid = Guid.NewGuid().ToString();

    db.Invitations.Add(invitation);
    await db.SaveChangesAsync();

    return Results.Ok(new { message = "Invitation created successfully!", inviteGuid = invitation.InviteGuid });
});

app.Run();

// Helper record for claiming gifts with a guest name
public record ClaimRequest(string GuestName);