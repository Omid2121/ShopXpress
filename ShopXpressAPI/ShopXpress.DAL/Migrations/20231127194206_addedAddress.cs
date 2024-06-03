using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_LocationId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LocationId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67d0efe5-5bdd-46a6-b75c-1a115039b4db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3dfc4cd-701a-4223-8c41-89337e8255eb");

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

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67d0efe5-5bdd-46a6-b75c-1a115039b4db", null, "Administrator", "ADMINISTRATOR" },
                    { "f3dfc4cd-701a-4223-8c41-89337e8255eb", null, "Consumer", "CONSUMER" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationId",
                table: "Orders",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_LocationId",
                table: "Orders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
