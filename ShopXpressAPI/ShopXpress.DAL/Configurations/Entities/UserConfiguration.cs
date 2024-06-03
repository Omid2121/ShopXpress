using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Required fields
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(user => user.LastName).IsRequired().HasMaxLength(70);
        builder.Property(user => user.CartId).IsRequired();

        // User has a one-to-one relationship with Cart
        builder.HasOne(user => user.Cart)
            .WithOne(cart => cart.User)
            .HasForeignKey<User>(user => user.CartId);

        // User has a one-to-many relationship with Order
        builder.HasMany(user => user.Orders)
            .WithOne(order => order.User)
            .HasForeignKey(order => order.UserId);
    }
}
