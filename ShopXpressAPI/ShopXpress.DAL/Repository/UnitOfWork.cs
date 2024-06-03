using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShopXpress.DAL.Configurations;
using ShopXpress.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShopXpressDbContext _context;
    private BaseItemRepository _baseItems;
    private CartRepository _carts;
    private CartItemRepository _cartItems;
    private CategoryRepository _categories;
    private OrderRepository _orders;
    private OrderItemRepository _orderItems;
    private ProductRepository _products;

    public UnitOfWork(ShopXpressDbContext context)
    {
        _context = context;
    }

    public BaseItemRepository BaseItems => _baseItems ??= new BaseItemRepository(_context);
    public CartRepository Carts => _carts ??= new CartRepository(_context);
    public CartItemRepository CartItems => _cartItems ??= new CartItemRepository(_context);
    public CategoryRepository Categories => _categories ??= new CategoryRepository(_context);
    public OrderRepository Orders => _orders ??= new OrderRepository(_context);
    public OrderItemRepository OrderItems => _orderItems ??= new OrderItemRepository(_context);
    public ProductRepository Products => _products ??= new ProductRepository(_context);

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}

