using ShopXpress.DAL.Configurations;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Repository;

public class ProductRepository : GenericRepository<Product>
{
    public ProductRepository(ShopXpressDbContext context) : base(context)
    {
    }

    //TODO: GetTop4MostSoldProducts

    public override Task Insert(Product entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        entity.CreatedAt = DateTimeOffset.UtcNow;

        return base.Insert(entity);
    }

    public override void Update(Product entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        entity.ModifiedAt = DateTimeOffset.UtcNow;
        base.Update(entity);
    }

    public async Task<IEnumerable<Product>> Search(string searchString)
    {
        if (string.IsNullOrEmpty(searchString)) return await GetAll();

        var orderBy = new Func<IQueryable<Product>, IOrderedQueryable<Product>>(products => products.OrderByDescending(product => product.Title));
        searchString = searchString.ToLower();
        
        return await GetAll(product => product.Title.Contains(searchString)
        || (product.Description != null && product.Description.Contains(searchString))
        || product.Manufacturer.Contains(searchString)
        || product.Category.Name.Contains(searchString), orderBy: orderBy, includes: new List<string> { "Category" });
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
    {
        if (string.IsNullOrEmpty(category)) return await GetAll();

        return await GetAll(product => product.Category.Name.Contains(category, StringComparison.CurrentCultureIgnoreCase));
    }
}
