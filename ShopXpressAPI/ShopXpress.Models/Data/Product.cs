using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Models.Data;

public class Product : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Manufacturer { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public virtual ICollection<CartItem>? CartItems { get; set; }
    public virtual ICollection<OrderItem>? OrderItems { get; set; }
}
