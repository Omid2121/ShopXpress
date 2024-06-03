using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.Entities;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        // Required fields
        builder.Property(cartItem => cartItem.Id).IsRequired();
        builder.Property(cartItem => cartItem.Quantity).IsRequired();
        builder.Property(cartItem => cartItem.Total).IsRequired();
        builder.Property(cartItem => cartItem.CartId).IsRequired();
        builder.Property(cartItem => cartItem.ProductId).IsRequired();

        // CartItem has one Cart, while Cart has many CartItems
        builder.HasOne(cartItem => cartItem.Cart)
            .WithMany(cart => cart.CartItems)
            .HasForeignKey(cartItem => cartItem.CartId);

        // CartItem has one Product, while Product has many CartItems
        builder.HasOne(cartItem => cartItem.Product)
            .WithMany(product => product.CartItems)
            .HasForeignKey(cartItem => cartItem.ProductId);
    }
}
