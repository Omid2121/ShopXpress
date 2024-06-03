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

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Required fields
        builder.Property(category => category.Id).IsRequired();
        builder.Property(category => category.Name).IsRequired();

        // Category has many products, while product has one category
        builder.HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .HasForeignKey(product => product.CategoryId);

        builder.HasData(CategorySeedData.Categories());
    }
}
