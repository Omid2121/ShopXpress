using ShopXpress.Models.Data;
using ShopXpress.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Bll.DTOs;

public class CreateOrderDTO
{
    [DataType(DataType.Currency)]
    public required decimal Total { get; set; }
    public string? Address { get; set; }
    public required string UserId { get; set; }
    public virtual required ICollection<OrderItemDTO> OrderItems { get; set; }
}

public class OrderDTO : CreateOrderDTO
{
    public required string OrderNumber { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset ShippingDate { get; set; }
    public required Status Status { get; set; }

    public required Guid Id { get; set; }
    public required UserDTO User { get; set; }
}

public class UpdateOrderDTO : CreateOrderDTO
{}

public class ChangeOrderStatusDTO
{
    public required Status Status { get; set; }
}
