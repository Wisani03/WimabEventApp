using System.ComponentModel.DataAnnotations;

namespace WimabEventApp.Models
{
    public class Invitation
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }
        public Event? Event { get; set; }

        [Required]
        public string GuestName { get; set; } = string.Empty;
        
        // Both are optional individually, but the app logic can ensure at least one is provided
        public string? GuestEmail { get; set; }
        public string? GuestPhoneNumber { get; set; } 

        [Required]
        public string InviteGuid { get; set; } = Guid.NewGuid().ToString(); // Unique token for QR code & link

        public bool IsAccepted { get; set; } = false;
        public bool BringingPlusOne { get; set; } = false;
        public bool IsAttended { get; set; } = false; // Scanned at the door!
    }
}