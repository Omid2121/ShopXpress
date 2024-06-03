using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.Entities;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        // Required fields
        builder.Property(cart => cart.Id).IsRequired();
        builder.Property(cart => cart.Total).IsRequired();
        builder.Property(cart => cart.UserId).IsRequired();

        // Cart has one User, while User has one Cart
        builder.HasOne(cart => cart.User)
            .WithOne(user => user.Cart)
            .HasForeignKey<Cart>(cart => cart.UserId);

        // Cart has many CartItems, while CartItem has one Cart
        builder.HasMany(cart => cart.CartItems)
            .WithOne(cartItem => cartItem.Cart)
            .HasForeignKey(cartItem => cartItem.CartId);
    }
}
