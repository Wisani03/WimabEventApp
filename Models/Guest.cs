namespace WimabEventApp.Models
{
    public class Guest
    {
        public int Id { get; set; }

        public int EventId { get; set; } // Links the guest to a specific event

        public int? InvitationId { get; set; }
        public Invitation? Invitation { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string TicketCode { get; set; } = string.Empty; // Used for QR code check-in

        public bool IsAttending { get; set; }

        public string? DietaryRequirements { get; set; }

        public DateTime RSVPDate { get; set; } = DateTime.UtcNow;

        public string? PlusOneName { get; set; }
    }
}
