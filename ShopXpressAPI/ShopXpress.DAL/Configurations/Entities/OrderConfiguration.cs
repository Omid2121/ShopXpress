using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.Entities;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Required fields
        builder.Property(order => order.Id).IsRequired();
        builder.Property(order => order.OrderNumber).IsRequired();
        builder.Property(order => order.CreatedAt).IsRequired();
        builder.Property(order => order.ShippingDate).IsRequired();
        builder.Property(order => order.Status).IsRequired();
        builder.Property(order => order.Total).IsRequired();
        builder.Property(order => order.UserId).IsRequired();

        // Order has a one-to-many relationship with User
        builder.HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(order => order.UserId);

        // Order has a one-to-many relationship with OrderItem
        builder.HasMany(order => order.OrderItems)
            .WithOne(orderItem => orderItem.Order)
            .HasForeignKey(orderItem => orderItem.OrderId);
    }
}
