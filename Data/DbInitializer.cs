using WimabEventApp.Models;

namespace WimabEventApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // If products already exist, don't seed again
            if (context.Products.Any())
            {
                return; 
            }

            var products = new Product[]
            {
                // --- WEDDINGS & KITCHEN TEA ---
                new Product { Title = "Luxury Espresso Machine", Description = "Stainless steel bean-to-cup machine for the kitchen.", Price = 4500.00m, ImageUrl = "https://images.unsplash.com/photo-1517668808822-9ebb02f2a0e6?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "Crystal Champagne Flutes (Set of 6)", Description = "Elegant glassware for toast celebrations.", Price = 950.00m, ImageUrl = "https://images.unsplash.com/photo-1527061011665-3652c757a4d4?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "Enameled Cast Iron Dutch Oven", Description = "5.5-quart red pot for baking and slow-cooking.", Price = 2200.00m, ImageUrl = "https://images.unsplash.com/photo-1585515320310-259814833e62?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "Smart Air Fryer XXL", Description = "Digital dual-basket air fryer for oil-free cooking.", Price = 2999.00m, ImageUrl = "https://images.unsplash.com/photo-1556911220-e15b29be8c8f?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "Cordless Stick Vacuum Cleaner", Description = "Lightweight powerful vacuum for hard floors and carpets.", Price = 3800.00m, ImageUrl = "https://images.unsplash.com/photo-1558317374-067fb5f30001?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "16-Piece Stoneware Dinnerware Set", Description = "Modern matte-finish dining plates and bowls.", Price = 1250.00m, ImageUrl = "https://images.unsplash.com/photo-1615870216519-2f9fa575fa5c?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "Standing Kitchen Mixer", Description = "Professional bake mixer with stainless steel bowl.", Price = 6500.00m, ImageUrl = "https://images.unsplash.com/photo-1590736969955-71cc94901344?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "Luxury Percale Cotton Duvet Cover Set", Description = "Queen size breathable crisp white bed linens.", Price = 1499.00m, ImageUrl = "https://images.unsplash.com/photo-1522771739844-6a9f6d5f14af?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "Automatic Robotic Vacuum", Description = "Smart mapping floor cleaning robot with app control.", Price = 5999.00m, ImageUrl = "https://images.unsplash.com/photo-1518640467707-6811f4a6ab73?w=500", OccasionCategory = "Wedding" },
                new Product { Title = "Electric Kettle & Toaster Combo", Description = "Matching matte black breakfast set.", Price = 1699.00m, ImageUrl = "https://images.unsplash.com/photo-1544655406-38435d79fc5e?w=500", OccasionCategory = "Wedding" },

                // --- BIRTHDAYS ---
                new Product { Title = "Wireless Noise-Canceling Headphones", Description = "Over-ear bluetooth headphones with deep bass.", Price = 3200.00m, ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Smart Fitness Watch", Description = "Tracks heart rate, sleep, and daily workouts.", Price = 2799.00m, ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Portable Waterproof Bluetooth Speaker", Description = "Rugged outdoor speaker with 20hr battery life.", Price = 1899.00m, ImageUrl = "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Instant Film Camera Kit", Description = "Retro style camera with film pack and photo album.", Price = 1599.00m, ImageUrl = "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Gaming Mechanical Keyboard", Description = "RGB backlit wireless keyboard for gaming or coding.", Price = 1450.00m, ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Leather Weekender Duffel Bag", Description = "Genuine leather travel bag for weekend getaways.", Price = 3500.00m, ImageUrl = "https://images.unsplash.com/photo-1553062407-98eeb64c6a62?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Designer Scented Candle & Diffuser Gift Set", Description = "Luxury soy wax home fragrance collection.", Price = 750.00m, ImageUrl = "https://images.unsplash.com/photo-1608571423902-eed4a5ad8108?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Aromatherapy Essential Oil Diffuser", Description = "Ultrasonic mist humidifier with ambient LED light.", Price = 499.00m, ImageUrl = "https://images.unsplash.com/photo-1608571423902-eed4a5ad8108?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Cocktail Shaker & Bartender Tool Kit", Description = "Stainless steel mixology set with wooden stand.", Price = 899.00m, ImageUrl = "https://images.unsplash.com/photo-1514362545857-3bc16c4c7d1b?w=500", OccasionCategory = "Birthday" },
                new Product { Title = "Kindle E-Reader", Description = "Glare-free touchscreen digital book reader.", Price = 2899.00m, ImageUrl = "https://images.unsplash.com/photo-1544716278-ca5e3f4abd8c?w=500", OccasionCategory = "Birthday" },

                // --- BBQS & OUTDOORS ---
                new Product { Title = "Heavy Duty Stainless Steel Grill Set", Description = "Professional 5-piece barbecue grilling tools with case.", Price = 850.00m, ImageUrl = "https://images.unsplash.com/photo-1555396273-367ea4eb4db5?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Cast Iron Skillet & Press Kit", Description = "12-inch seasoned skillet for smash burgers and steaks.", Price = 999.00m, ImageUrl = "https://images.unsplash.com/photo-1584949513833-6448532f009e?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Portable Charcoal Kettle Braai", Description = "Compact outdoor grill for camping and picnics.", Price = 1750.00m, ImageUrl = "https://images.unsplash.com/photo-1555939594-58d7cb561ad1?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Insulated Cooler Box (50L)", Description = "Heavy-duty ice chest keeping drinks cold for days.", Price = 2499.00m, ImageUrl = "https://images.unsplash.com/photo-1563245372-f21724e3856d?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Wireless Digital Meat Thermometer", Description = "Bluetooth dual-probe thermometer for perfect meats.", Price = 1150.00m, ImageUrl = "https://images.unsplash.com/photo-1556910103-1c02745aae4d?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Outdoor Picnic Backpack for 4", Description = "Complete with cutlery, plates, wine glasses and blanket.", Price = 1350.00m, ImageUrl = "https://images.unsplash.com/photo-1526772662000-3f88f10405ff?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Tabletop Fire Pit Bowl", Description = "Smokeless mini patio fire pit for cozy evenings.", Price = 1650.00m, ImageUrl = "https://images.unsplash.com/photo-1508873696983-2df5c92013c7?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Heavy Leather Braai Apron & Gloves Set", Description = "Heat-resistant genuine leather safety apron.", Price = 999.00m, ImageUrl = "https://images.unsplash.com/photo-1556910638-1634a338274a?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Foldable Camping Chairs (Pair)", Description = "Sturdy padded outdoor chairs with cup holders.", Price = 1200.00m, ImageUrl = "https://images.unsplash.com/photo-1533873984035-25970a074684?w=500", OccasionCategory = "BBQ" },
                new Product { Title = "Cast Iron Potjiekos Pot (Size 3)", Description = "Traditional three-legged pot for outdoor stewing.", Price = 1150.00m, ImageUrl = "https://images.unsplash.com/photo-1545224182-5f398773c337?w=500", OccasionCategory = "BBQ" },

                // --- BABY SHOWERS & KIDS ---
                new Product { Title = "Baby Video Monitor with Night Vision", Description = "Secure digital color screen monitor with talk-back.", Price = 2499.00m, ImageUrl = "https://images.unsplash.com/photo-1515488042361-ee00e0ddd4e4?w=500", OccasionCategory = "Baby" },
                new Product { Title = "Organic Cotton Baby Clothes Bundle", Description = "Soft onesies, beanies, and blankets gift box.", Price = 799.00m, ImageUrl = "https://images.unsplash.com/photo-1522771739844-6a9f6d5f14af?w=500", OccasionCategory = "Baby" },
                new Product { Title = "Convertible Wooden Baby High Chair", Description = "Sturdy multi-stage high chair with safety harness.", Price = 1899.00m, ImageUrl = "https://images.unsplash.com/photo-1595450456528-98448f8f8b89?w=500", OccasionCategory = "Baby" },
                new Product { Title = "Baby Bath Tub & Care Station", Description = "Ergonomic infant bath tub with digital thermometer.", Price = 950.00m, ImageUrl = "https://images.unsplash.com/photo-1584132967334-10e028bd69f7?w=500", OccasionCategory = "Baby" },
                new Product { Title = "Musical Baby Mobile & Night Light", Description = "Crib mobile with soothing melodies and starry projection.", Price = 650.00m, ImageUrl = "https://images.unsplash.com/photo-1513151233558-d860c5398176?w=500", OccasionCategory = "Baby" },

                // --- HOUSEWARMING ---
                new Product { Title = "Indoor Snake Plant in Ceramic Pot", Description = "Low-maintenance air-purifying houseplant.", Price = 450.00m, ImageUrl = "https://images.unsplash.com/photo-1485955900006-10f4d324d411?w=500", OccasionCategory = "Housewarming" },
                new Product { Title = "Handmade Woven Jute Area Rug", Description = "Natural textured floor mat for living room or entryway.", Price = 1699.00m, ImageUrl = "https://images.unsplash.com/photo-1600121848594-d8644e57abab?w=500", OccasionCategory = "Housewarming" },
                new Product { Title = "Minimalist Wall Clock", Description = "Modern silent sweep wooden face wall timepiece.", Price = 599.00m, ImageUrl = "https://images.unsplash.com/photo-1563861826100-9cb868fdbe1c?w=500", OccasionCategory = "Housewarming" },
                new Product { Title = "Stainless Steel Cutlery Set (24-Piece)", Description = "Mirror polish dining knife, fork, and spoon set.", Price = 899.00m, ImageUrl = "https://images.unsplash.com/photo-1584269600464-37b1b58a9fe7?w=500", OccasionCategory = "Housewarming" },
                new Product { Title = "Luxury Bath Towel Bale (6-Piece)", Description = "Super absorbent 100% combed cotton bath towels.", Price = 999.00m, ImageUrl = "https://images.unsplash.com/photo-1616046229478-9901c5536a45?w=500", OccasionCategory = "Housewarming" },

                // --- GENERAL & CELEBRATIONS ---
                new Product { Title = "Champagne Gift Box with Truffles", Description = "Sparkling wine bottle paired with artisanal chocolates.", Price = 850.00m, ImageUrl = "https://images.unsplash.com/photo-1549465220-1a8b9238cd48?w=500", OccasionCategory = "General" },
                new Product { Title = "Professional Chef's Knife (8-inch)", Description = "High-carbon stainless steel forged kitchen knife.", Price = 1299.00m, ImageUrl = "https://images.unsplash.com/photo-1593618998160-e34014e67546?w=500", OccasionCategory = "General" },
                new Product { Title = "Wooden Charcuterie & Cheese Board", Description = "Acacia wood serving board with knife slot set.", Price = 699.00m, ImageUrl = "https://images.unsplash.com/photo-1507048331197-7d4af7087716?w=500", OccasionCategory = "General" },
                new Product { Title = "Smart LED Desk Lamp with Wireless Charger", Description = "Dimmable eye-care lamp with phone charging base.", Price = 750.00m, ImageUrl = "https://images.unsplash.com/photo-1534349762230-e0cadf39f571?w=500", OccasionCategory = "General" },
                new Product { Title = "Portable Juice Blender", Description = "USB rechargeable smoothie maker for active lifestyles.", Price = 550.00m, ImageUrl = "https://images.unsplash.com/photo-1570696219429-75b5a64a3875?w=500", OccasionCategory = "General" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}