using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Models.Data;

public class Category : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Product>? Products { get; set; } 
}
