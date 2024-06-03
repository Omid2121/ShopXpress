using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Models.Data;

public class Cart : IEntity
{
    public Guid Id { get; set; }
    public decimal Total { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
    public virtual ICollection<CartItem>? CartItems { get; set; }
}
