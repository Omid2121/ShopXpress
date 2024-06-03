using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Bll.DTOs;

public class CreateCategoryDTO
{
    [StringLength(30, MinimumLength = 3)]
    public required string Name { get; set; }
}

public class CategoryDTO : CreateCategoryDTO
{
    public required Guid Id { get; set; }
    public ICollection<ProductDTO>? Products { get; set; }
}

public class UpdateCategoryDTO : CreateCategoryDTO
{
}
