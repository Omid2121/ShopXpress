using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopXpress.DAL.Configurations.Entities;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations;

public class ShopXpressDbContext : IdentityDbContext<User>
{
    public ShopXpressDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<BaseItem> BaseItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Use TPT inheritance for BaseItem
        builder.Entity<BaseItem>().UseTptMappingStrategy();

        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new CartConfiguration());
        builder.ApplyConfiguration(new CartItemConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        
        base.OnModelCreating(builder);
    }
}
