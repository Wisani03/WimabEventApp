using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;
using WimabEventApp.Models;

var builder = WebApplication.CreateBuilder(args);

// SQLite database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=wimab_event.db"));

var app = builder.Build();

// Enables serving the wwwroot/index.html file automatically
app.UseDefaultFiles(); 
app.UseStaticFiles();

// The API endpoint to save RSVPs
app.MapPost("/api/rsvp", async (Guest guest, AppDbContext db) =>
{
    // Simple validation
    if (string.IsNullOrEmpty(guest.Name) || string.IsNullOrEmpty(guest.Surname))
        return Results.BadRequest("Name and Surname are required.");

  guest.RSVPDate = DateTime.Now;
    
    db.Guests.Add(guest);
    await db.SaveChangesAsync();
    
    return Results.Ok(new { message = "RSVP received successfully!" });
});

app.Run();