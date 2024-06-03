using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Models.Data;

public class BaseItem : IEntity
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }

    //public Guid ProductId { get; set; }
    //public Product Product { get; set; }
}
