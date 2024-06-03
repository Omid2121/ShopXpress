using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Bll.DTOs;

public class CreateCartItemDTO
{
    public required int Quantity { get; set; }
    public required Guid ProductId { get; set; }
}

public class CartItemDTO : CreateCartItemDTO
{
    public required Guid Id { get; set; }

    [DataType(DataType.Currency)]
    public required decimal Total { get; set; }
    public required string ProductTitle { get; set; }
}

public class UpdateCartItemDTO
{
    public required int Quantity { get; set; }
}
