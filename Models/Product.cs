namespace WimabEventApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string OccasionCategory { get; set; } = string.Empty; // e.g., "Wedding", "Birthday", "BBQ"
        public string GiftType { get; set; } = string.Empty; // e.g., "Men", "Women", "Boys", "Girls", "Couple", "Unisex"
    }
}

