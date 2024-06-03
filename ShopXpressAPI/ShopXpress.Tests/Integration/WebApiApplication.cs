using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopXpress.DAL.Configurations;
using ShopXpress.DAL.IRepository;
using ShopXpress.DAL.Repository;
using Xunit.Abstractions;

namespace ShopXpress.Tests.Integration
{
    public class WebApiApplication : WebApplicationFactory<Program>
    {
        protected UnitOfWork UnitOfWork { get; set; }
        private readonly ITestOutputHelper _testOutputHelper;

        public WebApiApplication(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    service => service.ServiceType == typeof(DbContextOptions<ShopXpressDbContext>));

                services.Remove(descriptor!);

                var authenticationDescriptor = services.SingleOrDefault(
                    service => service.ServiceType == typeof(AuthenticationService));

                services.Remove(authenticationDescriptor!);

                var authorizationDescriptor = services.SingleOrDefault(
                    service => service.ServiceType == typeof(IAuthorizationService));

                services.Remove(authorizationDescriptor!);

                string dbName = "InMemoryDbForTesting" + Guid.NewGuid().ToString();

                services.AddDbContext<ShopXpressDbContext>(options =>
                {
                    options.UseInMemoryDatabase(dbName);
                });
                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<ShopXpressDbContext>())
                {
                    try
                    {
                        UnitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>() as UnitOfWork
                        ?? throw new NullReferenceException("UnitOfWork is null");
                        appContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        _testOutputHelper.WriteLine(ex.Message);
                        throw;
                    }
                }
            });
            return base.CreateHost(builder);
        }
    }
}
