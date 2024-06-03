using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopXpress.DAL.Configurations.SeedData;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Required fields
        builder.Property(product => product.Id).IsRequired();
        builder.Property(product => product.Title).IsRequired().HasMaxLength(50);
        builder.Property(product => product.Manufacturer).IsRequired().HasMaxLength(50);
        builder.Property(product => product.UnitPrice).IsRequired();
        builder.Property(product => product.StockQuantity).IsRequired();
        builder.Property(product => product.CategoryId).IsRequired();

        // Product has a one-to-many relationship with Category
        builder.HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryId);

        // Product has a many-to-one relationship with CartItem
        builder.HasMany(product => product.CartItems)
            .WithOne(cartItem => cartItem.Product)
            .HasForeignKey(cartItem => cartItem.ProductId);

        // Product has a many-to-one relationship with OrderItem
        builder.HasMany(product => product.OrderItems)
            .WithOne(orderItem => orderItem.Product)
            .HasForeignKey(orderItem => orderItem.ProductId);

        builder.HasData(ProductSeedData.Products());
    }
}
