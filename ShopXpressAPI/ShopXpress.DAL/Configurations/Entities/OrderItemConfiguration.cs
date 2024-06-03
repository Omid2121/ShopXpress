using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.Entities;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        // Required fields
        builder.Property(orderItem => orderItem.Id).IsRequired();
        builder.Property(orderItem => orderItem.Quantity).IsRequired();
        builder.Property(orderItem => orderItem.Total).IsRequired();
        builder.Property(orderItem => orderItem.OrderId).IsRequired();
        builder.Property(orderItem => orderItem.ProductId).IsRequired();

        // OrderItem has a many-to-one relationship with Order
        builder.HasOne(orderItem => orderItem.Order)
            .WithMany(order => order.OrderItems)
            .HasForeignKey(orderItem => orderItem.OrderId);

        // OrderItem has a many-to-one relationship with Product
        builder.HasOne(orderItem => orderItem.Product)
            .WithMany(product => product.OrderItems)
            .HasForeignKey(orderItem => orderItem.ProductId);
    }
}
