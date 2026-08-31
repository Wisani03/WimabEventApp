using WimabEventApp.Models;

namespace WimabEventApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
           context.Database.EnsureCreated();

var imageMappings = new Dictionary<string, string>
{
    ["Air Fryer"] = "/images/gifts/air-fryer.jpg",
    ["16-Piece Dinnerware Set"] = "/images/gifts/dinnerware.jpg",
    ["24-Piece Cutlery Set"] = "/images/gifts/cutlery.jpg",
    ["Luxury Towel Set"] = "/images/gifts/towels.jpg",
    ["Queen Bedding Set"] = "/images/gifts/bedding.jpg",
    ["Electric Kettle"] = "/images/gifts/kettle.jpg",
    ["Blender"] = "/images/gifts/blender.jpg",
    ["Microwave Oven"] = "/images/gifts/microwave.jpg",
    ["Ladies Perfume Gift Set"] = "/images/gifts/perfume.jpg",
    ["Ladies Handbag"] = "/images/gifts/handbag.jpg",
    ["Jewellery Gift Box"] = "/images/gifts/jewellery.jpg",
    ["Men's Watch"] = "/images/gifts/mens-watch.jpg",
    ["Leather Wallet"] = "/images/gifts/wallet.jpg",
    ["Men's Grooming Set"] = "/images/gifts/grooming.jpg",
    ["Homeware Gift Voucher"] = "/images/gifts/voucher.jpg",
    ["Chocolate Gift Hamper"] = "/images/gifts/chocolate.jpg",
    ["Ladies Perfume"] = "/images/gifts/perfume.jpg",
    ["Skincare Gift Set"] = "/images/gifts/skincare.jpg",
    ["Spa Gift Voucher"] = "/images/gifts/spa.jpg",
    ["Men's Grooming Kit"] = "/images/gifts/grooming.jpg",
    ["Wireless Headphones"] = "/images/gifts/headphones.jpg",
    ["Girls Creative Art Set"] = "/images/gifts/art-set.jpg",
    ["Girls Backpack"] = "/images/gifts/backpack.jpg",
    ["Doll Gift Set"] = "/images/gifts/doll.jpg",
    ["Remote Control Car"] = "/images/gifts/remote-car.jpg",
    ["Football"] = "/images/gifts/football.jpg",
    ["Kids Gaming Headset"] = "/images/gifts/gaming-headset.jpg",
    ["Bluetooth Speaker"] = "/images/gifts/speaker.jpg",
    ["Chocolate Hamper"] = "/images/gifts/chocolate.jpg",
    ["Restaurant Gift Voucher"] = "/images/gifts/voucher.jpg",
    ["Baby Boy Clothing Bundle"] = "/images/gifts/baby-clothes.jpg",
    ["Baby Boy Blanket"] = "/images/gifts/baby-blanket.jpg",
    ["Baby Girl Clothing Bundle"] = "/images/gifts/baby-clothes.jpg",
    ["Baby Girl Blanket"] = "/images/gifts/baby-blanket.jpg",
    ["Nappy Hamper"] = "/images/gifts/nappy-hamper.jpg",
    ["Baby Bath & Care Set"] = "/images/gifts/baby-care.jpg",
    ["Baby Feeding Set"] = "/images/gifts/baby-feeding.jpg",
    ["Baby Monitor"] = "/images/gifts/baby-monitor.jpg",
    ["Braai Tool Set"] = "/images/gifts/braai-tools.jpg",
    ["Braai Apron"] = "/images/gifts/braai-apron.jpg",
    ["Cast Iron Potjie Pot"] = "/images/gifts/potjie.jpg",
    ["Outdoor Serving Set"] = "/images/gifts/serving-set.jpg",
    ["Picnic Basket"] = "/images/gifts/picnic-basket.jpg",
    ["50L Cooler Box"] = "/images/gifts/cooler-box.jpg",
    ["Outdoor Picnic Set"] = "/images/gifts/picnic-set.jpg",
    ["Braai Spice Hamper"] = "/images/gifts/braai-spices.jpg",
    ["Dinnerware Set"] = "/images/gifts/dinnerware.jpg",
    ["Kitchen Starter Set"] = "/images/gifts/dinnerware.jpg",
    ["Bedding Set"] = "/images/gifts/bedding.jpg",
    ["Toaster"] = "/images/gifts/toaster.jpg",
    ["Bath Towel Set"] = "/images/gifts/towels.jpg",
    ["Indoor Plant"] = "/images/gifts/plant.jpg",
    ["Gift Voucher"] = "/images/gifts/voucher.jpg",
    ["Chocolate Gift Box"] = "/images/gifts/chocolate.jpg"
};

if (context.Products.Any())
{
    var existingProducts = context.Products.ToList();

    foreach (var product in existingProducts)
    {
        if (imageMappings.TryGetValue(product.Title, out var imageUrl))
        {
            product.ImageUrl = imageUrl;
        }
    }

    context.SaveChanges();

    return;
}

            var products = new Product[]
            {
                new Product
                {
                    Title = "Air Fryer",
                    Description = "A practical kitchen appliance for quick and convenient family meals.",
                    Price = 1499.00m,
                    ImageUrl = "/images/gifts/air-fryer.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "16-Piece Dinnerware Set",
                    Description = "Modern dinnerware set suitable for everyday meals and entertaining guests.",
                    Price = 899.00m,
                    ImageUrl = "/images/gifts/dinnerware.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "24-Piece Cutlery Set",
                    Description = "Stainless steel cutlery set for a new home.",
                    Price = 699.00m,
                    ImageUrl = "/images/gifts/cutlery.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Luxury Towel Set",
                    Description = "Soft cotton towel set suitable for a couple starting a new home.",
                    Price = 699.00m,
                    ImageUrl = "/images/gifts/towels.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Queen Bedding Set",
                    Description = "Comfortable bedding set for a newly married couple.",
                    Price = 999.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Electric Kettle",
                    Description = "Fast-boiling electric kettle for everyday kitchen use.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/kettle.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Blender",
                    Description = "Multi-purpose blender for smoothies, sauces and everyday cooking.",
                    Price = 699.00m,
                    ImageUrl = "/images/gifts/blender.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Microwave Oven",
                    Description = "Compact microwave oven for convenient everyday meals.",
                    Price = 1299.00m,
                    ImageUrl = "/images/gifts/microwave.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Ladies Perfume Gift Set",
                    Description = "Elegant fragrance gift set suitable for the bride or a special woman.",
                    Price = 799.00m,
                    ImageUrl = "/images/gifts/perfume.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "Ladies Handbag",
                    Description = "Classic everyday handbag suitable for special occasions and daily use.",
                    Price = 899.00m,
                    ImageUrl = "/images/gifts/handbag.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "Jewellery Gift Box",
                    Description = "Elegant jewellery piece presented in a gift box.",
                    Price = 599.00m,
                    ImageUrl = "/images/gifts/jewellery.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "Men's Watch",
                    Description = "Classic men's wristwatch suitable for formal and everyday wear.",
                    Price = 899.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Leather Wallet",
                    Description = "Classic men's wallet with space for cards and cash.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Men's Grooming Set",
                    Description = "Personal grooming essentials presented as a practical gift set.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/perfume.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Homeware Gift Voucher",
                    Description = "A flexible gift voucher allowing the couple to choose what they need.",
                    Price = 1000.00m,
                    ImageUrl = "/images/gifts/dinnerware.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Chocolate Gift Hamper",
                    Description = "Assorted chocolates and sweet treats presented as a celebration hamper.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/perfume.jpg",
                    OccasionCategory = "Wedding",
                    GiftType = "Unisex"
                },

              
                new Product
                {
                    Title = "Ladies Perfume",
                    Description = "Beautiful fragrance suitable for a birthday celebration.",
                    Price = 699.00m,
                    ImageUrl = "/images/gifts/perfume.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "Skincare Gift Set",
                    Description = "A selection of everyday skincare products presented as a birthday gift.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/perfume.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "Ladies Handbag",
                    Description = "Stylish everyday handbag suitable for a birthday gift.",
                    Price = 799.00m,
                    ImageUrl = "/images/gifts/handbag.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "Spa Gift Voucher",
                    Description = "Gift voucher for a relaxing spa experience.",
                    Price = 750.00m,
                    ImageUrl = "/images/gifts/towels.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "Men's Watch",
                    Description = "Classic wristwatch suitable for everyday or formal wear.",
                    Price = 899.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Men's Grooming Kit",
                    Description = "Practical grooming essentials for everyday use.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Wireless Headphones",
                    Description = "Wireless headphones for music, entertainment and everyday use.",
                    Price = 999.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Leather Wallet",
                    Description = "Classic wallet suitable for everyday use.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Girls Creative Art Set",
                    Description = "Fun colouring and drawing set for creative children.",
                    Price = 299.00m,
                    ImageUrl = "/images/gifts/jewellery.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Girls"
                },

                new Product
                {
                    Title = "Girls Backpack",
                    Description = "Colourful everyday backpack suitable for school and outings.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/handbag.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Girls"
                },

                new Product
                {
                    Title = "Doll Gift Set",
                    Description = "Fun doll set suitable for a child's birthday celebration.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/jewellery.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Girls"
                },

                new Product
                {
                    Title = "Remote Control Car",
                    Description = "Fun remote control vehicle for children's entertainment.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Boys"
                },

                new Product
                {
                    Title = "Football",
                    Description = "Durable football suitable for outdoor play.",
                    Price = 299.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Boys"
                },

                new Product
                {
                    Title = "Kids Gaming Headset",
                    Description = "Comfortable gaming headset for young gamers.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Boys"
                },

                new Product
                {
                    Title = "Bluetooth Speaker",
                    Description = "Portable speaker suitable for music at home or outdoors.",
                    Price = 599.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Chocolate Hamper",
                    Description = "Assorted chocolates and sweet treats for a birthday celebration.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/perfume.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Restaurant Gift Voucher",
                    Description = "Flexible restaurant voucher for a birthday meal.",
                    Price = 500.00m,
                    ImageUrl = "/images/gifts/dinnerware.jpg",
                    OccasionCategory = "Birthday",
                    GiftType = "Unisex"
                },

               
                new Product
                {
                    Title = "Baby Boy Clothing Bundle",
                    Description = "Soft everyday clothing bundle for a baby boy.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "Baby",
                    GiftType = "Baby"
                },

                new Product
                {
                    Title = "Baby Boy Blanket",
                    Description = "Soft and comfortable blanket suitable for a newborn baby boy.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "Baby",
                    GiftType = "Baby"
                },

                new Product
                {
                    Title = "Baby Girl Clothing Bundle",
                    Description = "Soft everyday clothing bundle for a baby girl.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "Baby",
                    GiftType = "Baby"
                },

                new Product
                {
                    Title = "Baby Girl Blanket",
                    Description = "Soft and comfortable blanket suitable for a newborn baby girl.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "Baby",
                    GiftType = "Baby"
                },

                new Product
                {
                    Title = "Nappy Hamper",
                    Description = "Practical newborn essentials including nappies and baby care items.",
                    Price = 599.00m,
                    ImageUrl = "/images/gifts/towels.jpg",
                    OccasionCategory = "Baby",
                    GiftType = "Baby"
                },

                new Product
                {
                    Title = "Baby Bath & Care Set",
                    Description = "Baby bath and personal care essentials suitable for a newborn.",
                    Price = 449.00m,
                    ImageUrl = "/images/gifts/towels.jpg",
                    OccasionCategory = "Baby",
                    GiftType = "Baby"
                },

                new Product
                {
                    Title = "Baby Feeding Set",
                    Description = "Practical feeding essentials for new parents.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/dinnerware.jpg",
                    OccasionCategory = "Baby",
                    GiftType = "Baby"
                },

                new Product
                {
                    Title = "Baby Monitor",
                    Description = "Helpful monitoring device for keeping an eye on the baby.",
                    Price = 1499.00m,
                    ImageUrl = "/images/gifts/microwave.jpg",
                    OccasionCategory = "Baby",
                    GiftType = "Baby"
                },

              
                new Product
                {
                    Title = "Braai Tool Set",
                    Description = "Essential braai tools including tongs, spatula and fork.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/cutlery.jpg",
                    OccasionCategory = "BBQ",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Braai Apron",
                    Description = "Durable apron designed for outdoor cooking and braai days.",
                    Price = 299.00m,
                    ImageUrl = "/images/gifts/towels.jpg",
                    OccasionCategory = "BBQ",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Cast Iron Potjie Pot",
                    Description = "Traditional South African potjie pot for outdoor cooking.",
                    Price = 899.00m,
                    ImageUrl = "/images/gifts/dinnerware.jpg",
                    OccasionCategory = "BBQ",
                    GiftType = "Men"
                },

                new Product
                {
                    Title = "Outdoor Serving Set",
                    Description = "Practical serving accessories for outdoor gatherings.",
                    Price = 499.00m,
                    ImageUrl = "/images/gifts/cutlery.jpg",
                    OccasionCategory = "BBQ",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "Picnic Basket",
                    Description = "Attractive picnic basket suitable for outdoor meals and celebrations.",
                    Price = 599.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "BBQ",
                    GiftType = "Women"
                },

                new Product
                {
                    Title = "50L Cooler Box",
                    Description = "Large insulated cooler box for drinks and food at outdoor events.",
                    Price = 899.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "BBQ",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Outdoor Picnic Set",
                    Description = "Reusable plates, cups and cutlery for outdoor gatherings.",
                    Price = 699.00m,
                    ImageUrl = "/images/gifts/dinnerware.jpg",
                    OccasionCategory = "BBQ",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Braai Spice Hamper",
                    Description = "Selection of spices and sauces for South African braai lovers.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/perfume.jpg",
                    OccasionCategory = "BBQ",
                    GiftType = "Unisex"
                },

              
                new Product
                {
                    Title = "Air Fryer",
                    Description = "Convenient kitchen appliance for preparing everyday meals.",
                    Price = 1499.00m,
                    ImageUrl = "/images/gifts/air-fryer.jpg",
                    OccasionCategory = "Housewarming",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Dinnerware Set",
                    Description = "Modern plates and bowls for a new home.",
                    Price = 899.00m,
                    ImageUrl = "/images/gifts/dinnerware.jpg",
                    OccasionCategory = "Housewarming",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Kitchen Starter Set",
                    Description = "Collection of practical kitchen utensils for a new home.",
                    Price = 599.00m,
                    ImageUrl = "/images/gifts/cutlery.jpg",
                    OccasionCategory = "Housewarming",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Bedding Set",
                    Description = "Comfortable bedding set for a new bedroom.",
                    Price = 999.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "Housewarming",
                    GiftType = "Couple"
                },

                new Product
                {
                    Title = "Electric Kettle",
                    Description = "Fast-boiling kettle suitable for everyday home use.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/kettle.jpg",
                    OccasionCategory = "Housewarming",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Toaster",
                    Description = "Compact toaster for quick breakfasts.",
                    Price = 399.00m,
                    ImageUrl = "/images/gifts/microwave.jpg",
                    OccasionCategory = "Housewarming",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Bath Towel Set",
                    Description = "Soft cotton towels for a new home.",
                    Price = 699.00m,
                    ImageUrl = "/images/gifts/towels.jpg",
                    OccasionCategory = "Housewarming",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Indoor Plant",
                    Description = "Low-maintenance decorative plant suitable for the home.",
                    Price = 299.00m,
                    ImageUrl = "/images/gifts/bedding.jpg",
                    OccasionCategory = "Housewarming",
                    GiftType = "Unisex"
                },

                

                new Product
                {
                    Title = "Gift Voucher",
                    Description = "Flexible voucher allowing the recipient to choose their own gift.",
                    Price = 500.00m,
                    ImageUrl = "/images/gifts/dinnerware.jpg",
                    OccasionCategory = "General",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Chocolate Gift Box",
                    Description = "Assorted chocolates suitable for many celebrations.",
                    Price = 299.00m,
                    ImageUrl = "/images/gifts/perfume.jpg",
                    OccasionCategory = "General",
                    GiftType = "Unisex"
                },

                new Product
                {
                    Title = "Bluetooth Speaker",
                    Description = "Portable speaker suitable for music and entertainment.",
                    Price = 599.00m,
                    ImageUrl = "/images/gifts/mens-watch.jpg",
                    OccasionCategory = "General",
                    GiftType = "Unisex"
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}


