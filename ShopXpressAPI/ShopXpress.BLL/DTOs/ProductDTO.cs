using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Bll.DTOs;

public class CreateProductDTO
{
    [StringLength(50, MinimumLength = 3)]
    public required string Title { get; set; }
    public string? Description { get; set; }

    [StringLength(40, MinimumLength = 3)]
    public required string Manufacturer { get; set; }
    
    [DataType(DataType.Currency)]
    public required decimal UnitPrice { get; set; }
    public required int StockQuantity { get; set; }
    public required Guid CategoryId { get; set; }
}

public class ProductDTO : CreateProductDTO
{
    public required Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }
    public required string CategoryName { get; set; }
    public virtual ICollection<CartItemDTO>? CartItems { get; set; }
    public virtual ICollection<OrderItemDTO>? OrderItems { get; set; }
}

public class UpdateProductDTO : CreateProductDTO
{}
