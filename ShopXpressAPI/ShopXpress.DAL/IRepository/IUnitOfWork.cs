using ShopXpress.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.IRepository;

public interface IUnitOfWork : IDisposable
{
    BaseItemRepository BaseItems { get; }
    CartRepository Carts { get; }
    CartItemRepository CartItems { get; }
    CategoryRepository Categories { get; }
    OrderRepository Orders { get; }
    OrderItemRepository OrderItems { get; }
    ProductRepository Products { get;}
    Task Save();
    IDbTransaction BeginTransaction();
}
