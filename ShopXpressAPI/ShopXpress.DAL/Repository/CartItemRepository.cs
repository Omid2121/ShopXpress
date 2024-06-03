using ShopXpress.DAL.Configurations;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Repository;

public class CartItemRepository : GenericRepository<CartItem>
{
    public CartItemRepository(ShopXpressDbContext context) : base(context)
    {
    }

    //public override Task Insert(CartItem entity)
    //{
    //    if (entity == null) throw new ArgumentNullException(nameof(entity));

    //    entity.Total = entity.Quantity * entity.Product.UnitPrice;

    //    return base.Insert(entity);
    //}
}
