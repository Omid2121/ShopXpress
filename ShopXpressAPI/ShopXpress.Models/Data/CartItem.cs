using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Models.Data;

public class CartItem : BaseItem
{
    public required Guid CartId { get; set; }
    public required Cart Cart { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
