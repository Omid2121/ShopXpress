using Microsoft.EntityFrameworkCore;
using ShopXpress.DAL.Configurations;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Repository;

public class CartRepository : GenericRepository<Cart>
{
    public CartRepository(ShopXpressDbContext context) : base(context)
    {
    }

    //public override async Task Insert(Cart entity)
    //{
    //    if (entity == null) throw new ArgumentNullException(nameof(entity));

    //    entity.Total = entity.CartItems.Sum(cartItem => cartItem.Total);

    //    await base.Insert(entity);
    //}
}
