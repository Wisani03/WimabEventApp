using System.ComponentModel.DataAnnotations;

namespace WimabEventApp.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }
        public Event? Event { get; set; }

        // Optional link to the pre-seeded product catalog
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        // Nullable fields so batch requests containing only ProductIds pass model validation successfully
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        public decimal? Price { get; set; }
        
        public string? GiftUrl { get; set; } 

        public string? ImageUrl { get; set; } 
        
        public bool IsClaimed { get; set; } = false;
        
        public string? ClaimedByGuestName { get; set; }
    }
}