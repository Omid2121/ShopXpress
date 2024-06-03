using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15582aa9-1622-4c97-858d-6ae1a9d749e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2196cb8-a758-4d7a-9513-d245d3eb0b23");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67d0efe5-5bdd-46a6-b75c-1a115039b4db", null, "Administrator", "ADMINISTRATOR" },
                    { "f3dfc4cd-701a-4223-8c41-89337e8255eb", null, "Consumer", "CONSUMER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0339b7e5-2910-459b-9dd7-dd7f21cf3b67"), "Baby" },
                    { new Guid("03699920-2ced-490e-8c5f-699c2897770c"), "Pet" },
                    { new Guid("3658572e-5d7b-47c2-ab80-f8d6d8977017"), "Other" },
                    { new Guid("3be63b9d-0c02-4077-8d6a-d9e9f0945e19"), "Handmade" },
                    { new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), "Electronics" },
                    { new Guid("46c5ea6e-1143-4e0b-868e-12b88f2885f8"), "Grocery" },
                    { new Guid("4ab2f398-3e1d-4cd0-8c21-55766bac483a"), "Sports" },
                    { new Guid("55468074-b867-4dc9-b3dc-f3b4b890c6ac"), "Books" },
                    { new Guid("5fe177cd-aa1e-44be-81ad-7ba2dcb48cd5"), "Health" },
                    { new Guid("61547a5e-a885-4bae-b0e3-a233d9cb4692"), "Toys" },
                    { new Guid("66b6f25b-7db1-4c6e-87b4-17b6dd781018"), "Industrial" },
                    { new Guid("71ca42f5-3c50-4be7-bde5-d1d68b2bed41"), "Music" },
                    { new Guid("8fa0d957-3aa3-40e3-97c6-c18c2c2d84d7"), "Garden" },
                    { new Guid("a1ee8039-f651-4850-8cb1-ac1377eb7405"), "Games" },
                    { new Guid("a5c375d9-ed54-4752-a4f0-6f13a8a3d2bf"), "Automotive" },
                    { new Guid("ad2cb3c0-17e2-4837-a96c-2e2756929859"), "Furniture" },
                    { new Guid("ae99f4ce-bfd2-47d0-af39-421dfa008b4a"), "Jewelry" },
                    { new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), "Clothing" },
                    { new Guid("cc2b18a7-22af-4ad5-abc8-712b2b3588b6"), "Beauty" },
                    { new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), "Food" },
                    { new Guid("d998f5f4-0f79-42b1-abd2-21014501f5b6"), "Movies" },
                    { new Guid("f84014a7-59df-4707-aa2c-5db4c49f81d4"), "Tools" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Manufacturer", "ModifiedAt", "StockQuantity", "Title", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("074f7fa1-aeb8-4ff8-9904-a7718ee35e06"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Lightweight and comfortable running shoes for athletes and fitness enthusiasts.", "Runner's Choice", null, 20, "Men's Running Shoes", 69.99m },
                    { new Guid("15478609-aa59-48ee-b8b8-449e75d1a56d"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High-quality, noise-canceling wireless headphones for an immersive audio experience.", "SoundWave Technologies", null, 20, "Wireless Bluetooth Headphones", 129.99m },
                    { new Guid("2021306e-f927-403a-b6de-b4d073a0505f"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Precision gaming mouse with customizable features for gamers.", "GamePro", null, 20, "Wireless Gaming Mouse", 49.99m },
                    { new Guid("323d8bc8-1322-4582-bc3b-f9048b549cbb"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Compact and portable Bluetooth speaker for on-the-go music.", "SonicBeats", null, 20, "Bluetooth Speaker", 39.99m },
                    { new Guid("3ff6f535-a717-4085-8a30-eb48136f6e83"), new Guid("4ab2f398-3e1d-4cd0-8c21-55766bac483a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Non-slip, eco-friendly yoga mat for a comfortable workout experience.", "ZenFitness", null, 20, "Yoga Mat", 24.99m },
                    { new Guid("4ee3b8bb-6be2-43e2-bed8-c0f69ba5269e"), new Guid("ad2cb3c0-17e2-4837-a96c-2e2756929859"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cozy and stylish handwoven throw blanket for your home decor.", "WeaveCrafters", null, 20, "Handwoven Throw Blanket", 29.99m },
                    { new Guid("586d8b68-b8d3-4322-9edd-0dcc1aea93dc"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Stylish and functional leather wallet with ample card and cash storage.", "LuxeLeather", null, 20, "Women's Leather Wallet", 49.99m },
                    { new Guid("66020790-d1ee-41b0-896b-f4ce8abcccfe"), new Guid("f84014a7-59df-4707-aa2c-5db4c49f81d4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Durable and eco-friendly bamboo cutting boards for your kitchen.", "GreenCut", null, 20, "Bamboo Cutting Board Set", 34.99m },
                    { new Guid("6ca2a7d1-bcc3-42f8-8d09-90ea962dbeef"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Stay connected with your home from anywhere with this HD security camera.", "SecureGuard", null, 20, "Smart Home Security Camera", 79.99m },
                    { new Guid("6e4e9909-89c3-428c-ac75-d2bc4420bfee"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Capture stunning photos and videos with this advanced digital camera.", "PixelPro", null, 20, "Digital Camera", 499.99m },
                    { new Guid("785996b1-8bcc-48f5-a0c7-0cb348ccedee"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nutrient-rich organic quinoa for a healthy and versatile grain option.", "EarthGrains", null, 20, "Organic Quinoa", 9.99m },
                    { new Guid("84d5c8ec-eae5-46d6-a1c9-ea91f4e3472d"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Indulge in the rich and delicious world of gourmet chocolate truffles.", "ChocoBliss", null, 20, "Gourmet Chocolate Truffles", 24.99m },
                    { new Guid("8939dbdc-e1ec-41c7-9984-f20eac3e4660"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Control your home's temperature remotely with this energy-efficient smart thermostat.", "EcoHeat", null, 20, "Smart Thermostat", 119.99m },
                    { new Guid("bca82d72-47fe-47ac-82c3-4e222276de6e"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Premium organic green tea leaves for a soothing and healthy beverage.", "Nature's Brew", null, 20, "Organic Green Tea", 12.99m },
                    { new Guid("ca579230-cf47-4fb3-b9c3-1aff753fed42"), new Guid("4ab2f398-3e1d-4cd0-8c21-55766bac483a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Eco-friendly and leak-proof stainless steel water bottle for hydration on the move.", "AquaPure", null, 20, "Stainless Steel Water Bottle", 19.99m },
                    { new Guid("da8fdd50-0900-408e-9a40-df8b3868ced4"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Keep your devices charged on the go with this high-capacity power bank.", "PowerUp Tech", null, 20, "Portable Power Bank", 39.99m },
                    { new Guid("f06b6a44-3597-499c-9b32-15e301f7884c"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Premium roasted coffee beans for the coffee connoisseur.", "BeanBliss", null, 20, "Gourmet Coffee Beans", 16.99m },
                    { new Guid("f1044f32-f4a1-4bcd-a622-821ef38c184c"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Handcrafted genuine leather messenger bag for a classic, stylish look.", "RetroCraft", null, 20, "Vintage Leather Messenger Bag", 89.99m },
                    { new Guid("f6e34e00-c9a2-4e67-bde2-2de57f8bb188"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Comfortable and stylish running shorts for active women.", "FitFemme", null, 20, "Women's Running Shorts", 29.99m },
                    { new Guid("febe4508-eee2-47cb-956f-585e1c281c65"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Classic and durable denim jeans for a timeless wardrobe staple.", "DenimCraft", null, 20, "Men's Denim Jeans", 49.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67d0efe5-5bdd-46a6-b75c-1a115039b4db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3dfc4cd-701a-4223-8c41-89337e8255eb");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0339b7e5-2910-459b-9dd7-dd7f21cf3b67"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("03699920-2ced-490e-8c5f-699c2897770c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3658572e-5d7b-47c2-ab80-f8d6d8977017"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3be63b9d-0c02-4077-8d6a-d9e9f0945e19"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("46c5ea6e-1143-4e0b-868e-12b88f2885f8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55468074-b867-4dc9-b3dc-f3b4b890c6ac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5fe177cd-aa1e-44be-81ad-7ba2dcb48cd5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("61547a5e-a885-4bae-b0e3-a233d9cb4692"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66b6f25b-7db1-4c6e-87b4-17b6dd781018"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("71ca42f5-3c50-4be7-bde5-d1d68b2bed41"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8fa0d957-3aa3-40e3-97c6-c18c2c2d84d7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1ee8039-f651-4850-8cb1-ac1377eb7405"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a5c375d9-ed54-4752-a4f0-6f13a8a3d2bf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ae99f4ce-bfd2-47d0-af39-421dfa008b4a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc2b18a7-22af-4ad5-abc8-712b2b3588b6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d998f5f4-0f79-42b1-abd2-21014501f5b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("074f7fa1-aeb8-4ff8-9904-a7718ee35e06"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15478609-aa59-48ee-b8b8-449e75d1a56d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2021306e-f927-403a-b6de-b4d073a0505f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("323d8bc8-1322-4582-bc3b-f9048b549cbb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3ff6f535-a717-4085-8a30-eb48136f6e83"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ee3b8bb-6be2-43e2-bed8-c0f69ba5269e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("586d8b68-b8d3-4322-9edd-0dcc1aea93dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66020790-d1ee-41b0-896b-f4ce8abcccfe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ca2a7d1-bcc3-42f8-8d09-90ea962dbeef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e4e9909-89c3-428c-ac75-d2bc4420bfee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("785996b1-8bcc-48f5-a0c7-0cb348ccedee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84d5c8ec-eae5-46d6-a1c9-ea91f4e3472d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8939dbdc-e1ec-41c7-9984-f20eac3e4660"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bca82d72-47fe-47ac-82c3-4e222276de6e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca579230-cf47-4fb3-b9c3-1aff753fed42"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da8fdd50-0900-408e-9a40-df8b3868ced4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f06b6a44-3597-499c-9b32-15e301f7884c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1044f32-f4a1-4bcd-a622-821ef38c184c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6e34e00-c9a2-4e67-bde2-2de57f8bb188"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("febe4508-eee2-47cb-956f-585e1c281c65"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4ab2f398-3e1d-4cd0-8c21-55766bac483a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ad2cb3c0-17e2-4837-a96c-2e2756929859"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d06c834b-b93e-4eb9-9b70-253709130797"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f84014a7-59df-4707-aa2c-5db4c49f81d4"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15582aa9-1622-4c97-858d-6ae1a9d749e3", null, "Consumer", "CONSUMER" },
                    { "c2196cb8-a758-4d7a-9513-d245d3eb0b23", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
