namespace WimabEventApp.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsAttending { get; set; }
        public string? DietaryRequirements { get; set; }
        
        public DateTime RSVPDate { get; set; } 
    }
}