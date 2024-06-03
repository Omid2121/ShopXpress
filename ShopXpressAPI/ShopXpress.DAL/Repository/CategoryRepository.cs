using ShopXpress.DAL.Configurations;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Repository;

public class CategoryRepository : GenericRepository<Category>
{
    public CategoryRepository(ShopXpressDbContext context) : base(context)
    {
    }
}
