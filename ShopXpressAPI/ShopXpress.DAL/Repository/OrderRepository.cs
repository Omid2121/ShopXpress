using ShopXpress.DAL.Configurations;
using ShopXpress.Models.Data;
using ShopXpress.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Repository;

public class OrderRepository : GenericRepository<Order>
{
    public OrderRepository(ShopXpressDbContext context) : base(context)
    {
    }
}
