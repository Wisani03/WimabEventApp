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

// The API endpoint to save RSVPs
app.MapPost("/api/rsvp", async (Guest guest, AppDbContext db) =>
{
    if (string.IsNullOrEmpty(guest.Name) || string.IsNullOrEmpty(guest.Surname))
        return Results.BadRequest("Name and Surname are required.");

    guest.RSVPDate = DateTime.Now;
    
    db.Guests.Add(guest);
    await db.SaveChangesAsync();
    
    return Results.Ok(new { message = "RSVP received successfully!" });
});

// NEW: API to get all RSVP'd guests
app.MapGet("/api/guests", async (AppDbContext db) => 
    await db.Guests.ToListAsync());

// The API endpoint to get the list of gifts
app.MapGet("/api/gifts", (AppDbContext db) => 
{
    return db.Gifts.ToList();
});

// Populate initial gifts if the table is empty
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
   
    db.Database.EnsureCreated(); 
    
    if (!db.Gifts.Any())
    {
        db.Gifts.AddRange(
            new Gift { Name = "Toaster", Description = "A silver 2-slice toaster", Price = 450.00m },
            new Gift { Name = "Blender", Description = "High-speed kitchen blender", Price = 800.00m },
            new Gift { Name = "Coffee Maker", Description = "Drip coffee machine", Price = 650.00m }
        );
        db.SaveChanges();
    }
}

app.MapPost("/api/gift/claim/{id}", async (int id, AppDbContext db) =>
{
    var gift = await db.Gifts.FindAsync(id);
    if (gift == null) return Results.NotFound();

    gift.IsClaimed = true;
    await db.SaveChangesAsync();

    return Results.Ok(new { message = "Gift claimed successfully!" });
});

// API endpoint to add a new gift
app.MapPost("/api/gifts/add", async (Gift gift, AppDbContext db) =>
{
    gift.IsClaimed = false; // New gifts are never claimed by default
    db.Gifts.Add(gift);
    await db.SaveChangesAsync();
    return Results.Ok(new { message = "Gift added successfully!" });
});

// API endpoint to delete a gift
app.MapDelete("/api/gifts/delete/{id}", async (int id, AppDbContext db) =>
{
    var gift = await db.Gifts.FindAsync(id);
    if (gift == null) return Results.NotFound();

    db.Gifts.Remove(gift);
    await db.SaveChangesAsync();
    return Results.Ok(new { message = "Gift deleted successfully!" });
});

app.Run();