using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class modifiedSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a94b3162-0edc-44b5-a6a4-6ea9a149de7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bae6bc51-a327-4609-8778-9f2bc01203ee");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00ee1325-9a06-42f2-807a-aa4da4b142f3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05982deb-e695-4fd2-8b6f-792ef1844524"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a9c2efc-e926-4f05-8e60-5c32e68256f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("255ac080-476e-41de-8c7d-72f269555cc7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2bfd9e4b-b895-4407-93e9-d06dd97091ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("38edc650-081f-4a0a-8061-c17501311f8f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5cda17d6-fca6-4c76-94a2-3856a4bbde97"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6233a902-dff6-40cc-a2d9-29c35abb23ea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6bff8586-0738-469d-87b7-02897961513d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("711d8d31-4273-464c-8a3c-16c1aa10e949"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d951e6b-4bda-4cfc-87c9-5d85620b0895"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a8b4676f-0833-47c0-99eb-0f946d73beac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6c626bd-c14b-4319-be91-9c319c599ac3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bead1a49-62a0-43d5-88e8-4e45ea7f283b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c18f6b94-57af-4426-b7a6-a24e5bf1f92f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c24b1e05-ac54-4985-b954-c1a89956bacb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d09db29b-f1d3-4a14-93c8-f99db3411313"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dfe62f16-4303-4771-977c-c4170400d33f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec2e6e25-bacf-4296-b7a4-3610687fb431"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f55ea150-9b79-4495-ab0f-cfe368f8ea6a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7036e331-117e-4e80-91eb-542f674a5fb4", null, "Administrator", "ADMINISTRATOR" },
                    { "8539346d-b695-49f9-915e-0ecf9dba9100", null, "Consumer", "CONSUMER" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Manufacturer", "ModifiedAt", "StockQuantity", "Title", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("033db315-eec9-4030-8a72-0af8d726987d"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(4993), new TimeSpan(0, 0, 0, 0, 0)), "Indulge in the rich and delicious world of gourmet chocolate truffles.", "ChocoBliss", null, 20, "Gourmet Chocolate Truffles", 24.99m },
                    { new Guid("2dac9c47-4f58-409b-a997-dd6094e15120"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5213), new TimeSpan(0, 0, 0, 0, 0)), "Stylish and functional leather wallet with ample card and cash storage.", "LuxeLeather", null, 20, "Women's Leather Wallet", 49.99m },
                    { new Guid("3048c008-afe1-4f70-a32c-c6a1c45398da"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5125), new TimeSpan(0, 0, 0, 0, 0)), "Comfortable and stylish running shorts for active women.", "FitFemme", null, 20, "Women's Running Shorts", 29.99m },
                    { new Guid("36baebe5-1896-47b5-a2b4-895c5803892f"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5111), new TimeSpan(0, 0, 0, 0, 0)), "Precision gaming mouse with customizable features for gamers.", "GamePro", null, 20, "Wireless Gaming Mouse", 49.99m },
                    { new Guid("3739770f-33fc-4adf-aec9-b40eba2b3ded"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 0, 0, 0, 0)), "Keep your devices charged on the go with this high-capacity power bank.", "PowerUp Tech", null, 20, "Portable Power Bank", 39.99m },
                    { new Guid("4c1eba31-05ee-4da8-88a7-fa8a3a3e56ee"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, 0, 0, 0, 0)), "Lightweight and comfortable running shoes for athletes and fitness enthusiasts.", "Runner's Choice", null, 20, "Men's Running Shoes", 69.99m },
                    { new Guid("577fc5fa-e3ca-4115-8de0-08d9bf764b0f"), new Guid("f84014a7-59df-4707-aa2c-5db4c49f81d4"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 0, 0, 0, 0)), "Durable and eco-friendly bamboo cutting boards for your kitchen.", "GreenCut", null, 20, "Bamboo Cutting Board Set", 34.99m },
                    { new Guid("665738e9-4082-4b62-b192-6afb12cfcc6f"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5171), new TimeSpan(0, 0, 0, 0, 0)), "Nutrient-rich organic quinoa for a healthy and versatile grain option.", "EarthGrains", null, 20, "Organic Quinoa", 9.99m },
                    { new Guid("7e85bada-2078-498e-8601-65c432d14f7a"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(4818), new TimeSpan(0, 0, 0, 0, 0)), "High-quality, noise-canceling wireless headphones for an immersive audio experience.", "SoundWave Technologies", null, 20, "Wireless Bluetooth Headphones", 129.99m },
                    { new Guid("8da867bc-e174-4d0d-a4a8-70c2445d1f38"), new Guid("4ab2f398-3e1d-4cd0-8c21-55766bac483a"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 0, 0, 0, 0)), "Eco-friendly and leak-proof stainless steel water bottle for hydration on the move.", "AquaPure", null, 20, "Stainless Steel Water Bottle", 19.99m },
                    { new Guid("91df33e9-b2d8-426c-9713-c3c0c07706b3"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(4837), new TimeSpan(0, 0, 0, 0, 0)), "Handcrafted genuine leather messenger bag for a classic, stylish look.", "RetroCraft", null, 20, "Vintage Leather Messenger Bag", 89.99m },
                    { new Guid("93c6e8ed-d9da-48f5-aefa-ad50bf5a8b8a"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5097), new TimeSpan(0, 0, 0, 0, 0)), "Control your home's temperature remotely with this energy-efficient smart thermostat.", "EcoHeat", null, 20, "Smart Thermostat", 119.99m },
                    { new Guid("9d38c244-b117-4c4e-884d-325623b5e417"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(4883), new TimeSpan(0, 0, 0, 0, 0)), "Stay connected with your home from anywhere with this HD security camera.", "SecureGuard", null, 20, "Smart Home Security Camera", 79.99m },
                    { new Guid("a887aa34-d322-4605-9248-66930dcb7302"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(4928), new TimeSpan(0, 0, 0, 0, 0)), "Capture stunning photos and videos with this advanced digital camera.", "PixelPro", null, 20, "Digital Camera", 499.99m },
                    { new Guid("b0f0e931-7e13-49b2-88be-0b509d8a53a0"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(4899), new TimeSpan(0, 0, 0, 0, 0)), "Premium organic green tea leaves for a soothing and healthy beverage.", "Nature's Brew", null, 20, "Organic Green Tea", 12.99m },
                    { new Guid("b4778ba9-1693-4c5d-b785-f1e4a26845bd"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5082), new TimeSpan(0, 0, 0, 0, 0)), "Classic and durable denim jeans for a timeless wardrobe staple.", "DenimCraft", null, 20, "Men's Denim Jeans", 49.99m },
                    { new Guid("d87157fd-4894-473c-bddd-bcb5dfc91218"), new Guid("ad2cb3c0-17e2-4837-a96c-2e2756929859"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(4979), new TimeSpan(0, 0, 0, 0, 0)), "Cozy and stylish handwoven throw blanket for your home decor.", "WeaveCrafters", null, 20, "Handwoven Throw Blanket", 29.99m },
                    { new Guid("eb76e71d-9682-4af9-855a-1cd720eb3286"), new Guid("4ab2f398-3e1d-4cd0-8c21-55766bac483a"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5023), new TimeSpan(0, 0, 0, 0, 0)), "Non-slip, eco-friendly yoga mat for a comfortable workout experience.", "ZenFitness", null, 20, "Yoga Mat", 24.99m },
                    { new Guid("efac08f2-935b-4c00-8565-766c08c8ef79"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 0, 0, 0, 0)), "Compact and portable Bluetooth speaker for on-the-go music.", "SonicBeats", null, 20, "Bluetooth Speaker", 39.99m },
                    { new Guid("fd76d957-e3a9-4bd7-a8b5-8a87dc13d44d"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(2023, 11, 29, 19, 31, 58, 265, DateTimeKind.Unspecified).AddTicks(5481), new TimeSpan(0, 0, 0, 0, 0)), "Premium roasted coffee beans for the coffee connoisseur.", "BeanBliss", null, 20, "Gourmet Coffee Beans", 16.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7036e331-117e-4e80-91eb-542f674a5fb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8539346d-b695-49f9-915e-0ecf9dba9100");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("033db315-eec9-4030-8a72-0af8d726987d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2dac9c47-4f58-409b-a997-dd6094e15120"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3048c008-afe1-4f70-a32c-c6a1c45398da"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36baebe5-1896-47b5-a2b4-895c5803892f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3739770f-33fc-4adf-aec9-b40eba2b3ded"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c1eba31-05ee-4da8-88a7-fa8a3a3e56ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("577fc5fa-e3ca-4115-8de0-08d9bf764b0f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("665738e9-4082-4b62-b192-6afb12cfcc6f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e85bada-2078-498e-8601-65c432d14f7a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8da867bc-e174-4d0d-a4a8-70c2445d1f38"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("91df33e9-b2d8-426c-9713-c3c0c07706b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93c6e8ed-d9da-48f5-aefa-ad50bf5a8b8a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d38c244-b117-4c4e-884d-325623b5e417"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a887aa34-d322-4605-9248-66930dcb7302"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0f0e931-7e13-49b2-88be-0b509d8a53a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4778ba9-1693-4c5d-b785-f1e4a26845bd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d87157fd-4894-473c-bddd-bcb5dfc91218"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb76e71d-9682-4af9-855a-1cd720eb3286"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("efac08f2-935b-4c00-8565-766c08c8ef79"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd76d957-e3a9-4bd7-a8b5-8a87dc13d44d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a94b3162-0edc-44b5-a6a4-6ea9a149de7b", null, "Consumer", "CONSUMER" },
                    { "bae6bc51-a327-4609-8778-9f2bc01203ee", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Manufacturer", "ModifiedAt", "StockQuantity", "Title", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("00ee1325-9a06-42f2-807a-aa4da4b142f3"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Premium organic green tea leaves for a soothing and healthy beverage.", "Nature's Brew", null, 20, "Organic Green Tea", 12.99m },
                    { new Guid("05982deb-e695-4fd2-8b6f-792ef1844524"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Stylish and functional leather wallet with ample card and cash storage.", "LuxeLeather", null, 20, "Women's Leather Wallet", 49.99m },
                    { new Guid("0a9c2efc-e926-4f05-8e60-5c32e68256f0"), new Guid("4ab2f398-3e1d-4cd0-8c21-55766bac483a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Eco-friendly and leak-proof stainless steel water bottle for hydration on the move.", "AquaPure", null, 20, "Stainless Steel Water Bottle", 19.99m },
                    { new Guid("255ac080-476e-41de-8c7d-72f269555cc7"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Classic and durable denim jeans for a timeless wardrobe staple.", "DenimCraft", null, 20, "Men's Denim Jeans", 49.99m },
                    { new Guid("2bfd9e4b-b895-4407-93e9-d06dd97091ae"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High-quality, noise-canceling wireless headphones for an immersive audio experience.", "SoundWave Technologies", null, 20, "Wireless Bluetooth Headphones", 129.99m },
                    { new Guid("38edc650-081f-4a0a-8061-c17501311f8f"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Capture stunning photos and videos with this advanced digital camera.", "PixelPro", null, 20, "Digital Camera", 499.99m },
                    { new Guid("5cda17d6-fca6-4c76-94a2-3856a4bbde97"), new Guid("ad2cb3c0-17e2-4837-a96c-2e2756929859"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cozy and stylish handwoven throw blanket for your home decor.", "WeaveCrafters", null, 20, "Handwoven Throw Blanket", 29.99m },
                    { new Guid("6233a902-dff6-40cc-a2d9-29c35abb23ea"), new Guid("f84014a7-59df-4707-aa2c-5db4c49f81d4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Durable and eco-friendly bamboo cutting boards for your kitchen.", "GreenCut", null, 20, "Bamboo Cutting Board Set", 34.99m },
                    { new Guid("6bff8586-0738-469d-87b7-02897961513d"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Precision gaming mouse with customizable features for gamers.", "GamePro", null, 20, "Wireless Gaming Mouse", 49.99m },
                    { new Guid("711d8d31-4273-464c-8a3c-16c1aa10e949"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Lightweight and comfortable running shoes for athletes and fitness enthusiasts.", "Runner's Choice", null, 20, "Men's Running Shoes", 69.99m },
                    { new Guid("7d951e6b-4bda-4cfc-87c9-5d85620b0895"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Control your home's temperature remotely with this energy-efficient smart thermostat.", "EcoHeat", null, 20, "Smart Thermostat", 119.99m },
                    { new Guid("a8b4676f-0833-47c0-99eb-0f946d73beac"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Handcrafted genuine leather messenger bag for a classic, stylish look.", "RetroCraft", null, 20, "Vintage Leather Messenger Bag", 89.99m },
                    { new Guid("b6c626bd-c14b-4319-be91-9c319c599ac3"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Premium roasted coffee beans for the coffee connoisseur.", "BeanBliss", null, 20, "Gourmet Coffee Beans", 16.99m },
                    { new Guid("bead1a49-62a0-43d5-88e8-4e45ea7f283b"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Keep your devices charged on the go with this high-capacity power bank.", "PowerUp Tech", null, 20, "Portable Power Bank", 39.99m },
                    { new Guid("c18f6b94-57af-4426-b7a6-a24e5bf1f92f"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Indulge in the rich and delicious world of gourmet chocolate truffles.", "ChocoBliss", null, 20, "Gourmet Chocolate Truffles", 24.99m },
                    { new Guid("c24b1e05-ac54-4985-b954-c1a89956bacb"), new Guid("afb069bc-7ae9-4b5e-bf74-3350fe341894"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Comfortable and stylish running shorts for active women.", "FitFemme", null, 20, "Women's Running Shorts", 29.99m },
                    { new Guid("d09db29b-f1d3-4a14-93c8-f99db3411313"), new Guid("4ab2f398-3e1d-4cd0-8c21-55766bac483a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Non-slip, eco-friendly yoga mat for a comfortable workout experience.", "ZenFitness", null, 20, "Yoga Mat", 24.99m },
                    { new Guid("dfe62f16-4303-4771-977c-c4170400d33f"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Stay connected with your home from anywhere with this HD security camera.", "SecureGuard", null, 20, "Smart Home Security Camera", 79.99m },
                    { new Guid("ec2e6e25-bacf-4296-b7a4-3610687fb431"), new Guid("4678572e-5d7b-47c2-ab80-f8d6d8977017"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Compact and portable Bluetooth speaker for on-the-go music.", "SonicBeats", null, 20, "Bluetooth Speaker", 39.99m },
                    { new Guid("f55ea150-9b79-4495-ab0f-cfe368f8ea6a"), new Guid("d06c834b-b93e-4eb9-9b70-253709130797"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nutrient-rich organic quinoa for a healthy and versatile grain option.", "EarthGrains", null, 20, "Organic Quinoa", 9.99m }
                });
        }
    }
}
