using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Bll.DTOs;

public class CreateCartDTO
{
    public Guid Id { get; set; }
    public required string UserId { get; set; }
}

public class CartDTO : CreateCartDTO
{
    [DataType(DataType.Currency)]
    public required decimal Total { get; set; }
    public required UserDTO User { get; set; }
    public virtual ICollection<CartItemDTO>? CartItems { get; set; }
}

public class UpdateCartDTO
{
    public required decimal Total { get; set; }
    public virtual ICollection<CartItemDTO>? CartItems { get; set; }
}
