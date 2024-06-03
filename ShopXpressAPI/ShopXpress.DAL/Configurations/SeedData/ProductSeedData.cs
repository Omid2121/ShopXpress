using Microsoft.AspNetCore.Http.HttpResults;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.SeedData;

public static class ProductSeedData
{
    private static Category FindCategory(string category)
    {
        var categories = CategorySeedData.Categories();
        return categories.Find(c => c.Name == category)!;
    }

    public static List<Product> Products()
    {
        return new List<Product>()
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Wireless Bluetooth Headphones",
                Description = "High-quality, noise-canceling wireless headphones for an immersive audio experience.",
                Manufacturer = "SoundWave Technologies",
                CategoryId = FindCategory("Electronics").Id,
                UnitPrice = 129.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Vintage Leather Messenger Bag",
                Description = "Handcrafted genuine leather messenger bag for a classic, stylish look.",
                Manufacturer = "RetroCraft",
                CategoryId = FindCategory("Clothing").Id,
                UnitPrice = 89.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Smart Home Security Camera",
                Description = "Stay connected with your home from anywhere with this HD security camera.",
                Manufacturer = "SecureGuard",
                CategoryId = FindCategory("Electronics").Id,
                UnitPrice = 79.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Organic Green Tea",
                Description = "Premium organic green tea leaves for a soothing and healthy beverage.",
                Manufacturer = "Nature's Brew",
                CategoryId = FindCategory("Food").Id,
                UnitPrice = 12.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Men's Running Shoes",
                Description = "Lightweight and comfortable running shoes for athletes and fitness enthusiasts.",
                Manufacturer = "Runner's Choice",
                CategoryId = FindCategory("Clothing").Id,
                UnitPrice = 69.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Digital Camera",
                Description = "Capture stunning photos and videos with this advanced digital camera.",
                Manufacturer = "PixelPro",
                CategoryId = FindCategory("Electronics").Id,
                UnitPrice = 499.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Handwoven Throw Blanket",
                Description = "Cozy and stylish handwoven throw blanket for your home decor.",
                Manufacturer = "WeaveCrafters",
                CategoryId = FindCategory("Furniture").Id,
                UnitPrice = 29.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Gourmet Chocolate Truffles",
                Description = "Indulge in the rich and delicious world of gourmet chocolate truffles.",
                Manufacturer = "ChocoBliss",
                CategoryId = FindCategory("Food").Id,
                UnitPrice = 24.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Portable Power Bank",
                Description = "Keep your devices charged on the go with this high-capacity power bank.",
                Manufacturer = "PowerUp Tech",
                CategoryId = FindCategory("Electronics").Id,
                UnitPrice = 39.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Yoga Mat",
                Description = "Non-slip, eco-friendly yoga mat for a comfortable workout experience.",
                Manufacturer = "ZenFitness",
                CategoryId = FindCategory("Sports").Id,
                UnitPrice = 24.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Men's Denim Jeans",
                Description = "Classic and durable denim jeans for a timeless wardrobe staple.",
                Manufacturer = "DenimCraft",
                CategoryId = FindCategory("Clothing").Id,
                UnitPrice = 49.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Smart Thermostat",
                Description = "Control your home's temperature remotely with this energy-efficient smart thermostat.",
                Manufacturer = "EcoHeat",
                CategoryId = FindCategory("Electronics").Id,
                UnitPrice = 119.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Wireless Gaming Mouse",
                Description = "Precision gaming mouse with customizable features for gamers.",
                Manufacturer = "GamePro",
                CategoryId = FindCategory("Electronics").Id,
                UnitPrice = 49.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Women's Running Shorts",
                Description = "Comfortable and stylish running shorts for active women.",
                Manufacturer = "FitFemme",
                CategoryId = FindCategory("Clothing").Id,
                UnitPrice = 29.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Organic Quinoa",
                Description = "Nutrient-rich organic quinoa for a healthy and versatile grain option.",
                Manufacturer = "EarthGrains",
                CategoryId = FindCategory("Food").Id,
                UnitPrice = 9.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Bamboo Cutting Board Set",
                Description = "Durable and eco-friendly bamboo cutting boards for your kitchen.",
                Manufacturer = "GreenCut",
                CategoryId = FindCategory("Tools").Id,
                UnitPrice = 34.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Bluetooth Speaker",
                Description = "Compact and portable Bluetooth speaker for on-the-go music.",
                Manufacturer = "SonicBeats",
                CategoryId = FindCategory("Electronics").Id,
                UnitPrice = 39.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Women's Leather Wallet",
                Description = "Stylish and functional leather wallet with ample card and cash storage.",
                Manufacturer = "LuxeLeather",
                CategoryId = FindCategory("Clothing").Id,
                UnitPrice = 49.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Stainless Steel Water Bottle",
                Description = "Eco-friendly and leak-proof stainless steel water bottle for hydration on the move.",
                Manufacturer = "AquaPure",
                CategoryId = FindCategory("Sports").Id,
                UnitPrice = 19.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Title = "Gourmet Coffee Beans",
                Description = "Premium roasted coffee beans for the coffee connoisseur.",
                Manufacturer = "BeanBliss",
                CategoryId = FindCategory("Food").Id,
                UnitPrice = 16.99M,
                StockQuantity = 20,
                CreatedAt = DateTimeOffset.UtcNow
            }
        };
    }
}
