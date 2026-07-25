using System.ComponentModel.DataAnnotations;

namespace WimabEventApp.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }
        public Event? Event { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public decimal Price { get; set; }
        
        public string GiftUrl { get; set; } = string.Empty;
        
        public bool IsClaimed { get; set; } = false;
        
        public string? ClaimedByGuestName { get; set; }
    }
}