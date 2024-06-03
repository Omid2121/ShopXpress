using ShopXpress.DAL.Configurations;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Repository;

public class OrderItemRepository : GenericRepository<OrderItem>
{
    public OrderItemRepository(ShopXpressDbContext context) : base(context)
    {
    }

    //public override Task Insert(OrderItem entity)
    //{
    //    if (entity == null) throw new ArgumentNullException(nameof(entity));

    //    entity.Total = entity.Quantity * entity.Product.UnitPrice;

    //    return base.Insert(entity);
    //}
}
