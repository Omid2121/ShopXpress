using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations
{
    internal class ShopXpressDbContextFactory : IDesignTimeDbContextFactory<ShopXpressDbContext>
    {
        /// <summary>
        /// Method ran by the compiler when creating a migration.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The instance of <see cref="CitizenTaxiDbContext"/></returns>
        public ShopXpressDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShopXpressDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(
                "SqlConnection"
                //"ReleaseSqlConnection"
            ));

            return new ShopXpressDbContext(optionsBuilder.Options);
        }
    }
}
