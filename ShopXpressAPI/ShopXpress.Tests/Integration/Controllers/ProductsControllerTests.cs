using Azure;
using Newtonsoft.Json;
using ShopXpress.Bll.DTOs;
using ShopXpress.DAL.Configurations.SeedData;
using ShopXpress.DAL.Repository;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ShopXpress.Tests.Integration.Controllers
{
    public class ProductsControllerTests : WebApiApplication
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;
        private List<Product> Products { get; set; } = new();

        public ProductsControllerTests(UnitOfWork unitOfWork, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _client = new WebApiApplication(_testOutputHelper).CreateClient();
            Products = ProductSeedData.Products();
        }

        [Fact]
        public async Task GetProducts_Always_ReturnsAllProducts()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(HttpHelper.Urls.Products);
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadFromJsonAsync<List<Product>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            results.Count.Should().Be(Products.Count);
            results.Should().BeEquivalentTo(Products);
        }

        [Fact]
        public async Task GetProduct_WithValidId_ReutrnsProduct()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.Products}/{Products[0].Id}");
            var result = await response.Content.ReadFromJsonAsync<Product>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeEquivalentTo(Products[0]);
        }

        [Fact]
        public async Task GetProduct_WithNewId_ReturnsNotFound()
        {
            // Arrange
            var newId = Guid.NewGuid();

            // Act
            var response = await _client.GetAsync($"{HttpHelper.Urls.Products}/{newId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateProduct_WithValidModel_ReturnsCreated()
        {
            // Arrange
            CreateProductDTO productDTO = new()
            {
                Title = "Test Product",
                Description = "Test Description",
                Manufacturer = "Test Manufacturer",
                UnitPrice = 10.99m,
                StockQuantity = 10,
                CategoryId = Guid.Parse("4678572e-5d7b-47c2-ab80-f8d6d8977017")
            };
            // Act
            var content = new StringContent(JsonConvert.SerializeObject(productDTO), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.Products, content);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateProduct_WithInvalidModel_ReturnsBadRequest()
        {
            // Arrange
            Product product = new();

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(HttpHelper.Urls.Products, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateProduct_WithValidModel_ReturnsNoContent()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            Category category = new()
            {
                Id = categoryId,
                Name = "Test Category",
            };
            Product product = new()
            {
                Id = Products[0].Id,
                Title = "Test Product",
                Description = "Test Description",
                Manufacturer = "Test Manufacturer",
                UnitPrice = 10.99m,
                StockQuantity = 10,
                CreatedAt = DateTime.Now,
                CategoryId = categoryId,
                Category = category
            };

            // Act 
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.Products}/{product.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateProduct_WithInvalidModel_ReturnsBadRequest()
        {
            // Arrange
            Product product = new() { Id = Guid.Empty};

            // Act
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{HttpHelper.Urls.Products}/{product.Id}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteProduct_WithValidId_ReturnsNoContent()
        {
            // Arrange

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.Products}/{Products[3].Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteProduct_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var newId = Guid.NewGuid();

            // Act
            var response = await _client.DeleteAsync($"{HttpHelper.Urls.Products}/{newId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
