using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;
using WimabEventApp.Models;

namespace WimabEventApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WishlistController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/products (Fetches the pre-seeded catalog, with optional category filtering)
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] string? category)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                query = query.Where(p => p.OccasionCategory == category);
            }
            return await query.ToListAsync();
        }

        // GET: api/events/{eventId}/wishlist (Fetches all wishlist items for a specific event - Host view)
        [HttpGet("events/{eventId}/wishlist")]
        public async Task<ActionResult<IEnumerable<WishlistItem>>> GetEventWishlist(int eventId)
        {
            var items = await _context.WishlistItems
                .Include(w => w.Product)
                .Where(w => w.EventId == eventId)
                .ToListAsync();

            return Ok(items);
        }

        // GET: api/public/events/{eventId}/wishlist (Public endpoint for guests to view the registry)
        [HttpGet("public/events/{eventId}/wishlist")]
        public async Task<ActionResult<IEnumerable<WishlistItem>>> GetPublicEventWishlist(int eventId)
        {
            var items = await _context.WishlistItems
                .Include(w => w.Product)
                .Where(w => w.EventId == eventId)
                .ToListAsync();

            return Ok(items);
        }

        // POST: api/events/{eventId}/wishlist (Adds single or multiple items in batch)
        [HttpPost("events/{eventId}/wishlist")]
        public async Task<IActionResult> AddWishlistItems(int eventId, [FromBody] List<WishlistItem> items)
        {
            var eventExists = await _context.Events.AnyAsync(e => e.Id == eventId);
            if (!eventExists) return NotFound(new { message = "Event not found." });

            foreach (var item in items)
            {
                item.EventId = eventId;
                item.Event = null;
                item.IsClaimed = false;

                // If the user picked an item from the pre-seeded catalog, pull details automatically
                if (item.ProductId.HasValue)
                {
                    var product = await _context.Products.FindAsync(item.ProductId.Value);
                    if (product != null)
                    {
                        item.Name = product.Title;
                        item.Description = product.Description;
                        item.Price = product.Price;
                        item.ImageUrl = product.ImageUrl;
                        item.GiftUrl = string.IsNullOrEmpty(item.GiftUrl) ? string.Empty : item.GiftUrl;
                    }
                }

                _context.WishlistItems.Add(item);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Wishlist items added successfully!" });
        }

        // POST: api/wishlist/claim/{id} (Allows guests to claim a gift)
        [HttpPost("wishlist/claim/{id}")]
        public async Task<IActionResult> ClaimGift(int id, [FromBody] ClaimRequest request)
        {
            var item = await _context.WishlistItems.FindAsync(id);
            if (item == null) return NotFound(new { message = "Gift not found." });

            item.IsClaimed = true;
            item.ClaimedByGuestName = request.GuestName;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Gift claimed successfully!" });
        }

        // DELETE: api/events/{eventId}/wishlist/{id} (Removes an item from the event wishlist)
        [HttpDelete("events/{eventId}/wishlist/{id}")]
        public async Task<IActionResult> DeleteWishlistItem(int eventId, int id)
        {
            var item = await _context.WishlistItems.FirstOrDefaultAsync(w => w.Id == id && w.EventId == eventId);
            if (item == null) return NotFound(new { message = "Wishlist item not found." });

            _context.WishlistItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    // Helper record for claiming gifts with a guest name
    public record ClaimRequest(string GuestName);
}