
using ShopXpress.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Models.Data;

public class Order : IEntity
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ShippingDate { get; set; }
    public Status Status { get; set; }
    public decimal Total { get; set; }
    public string Address { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
