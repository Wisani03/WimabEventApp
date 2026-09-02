using System.ComponentModel.DataAnnotations;

namespace WimabEventApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string VenueLocation { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
        public string Attire { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public DateTime? RsvpDeadline { get; set; }

        // Navigation properties initialized to prevent null warnings
        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
    }
}