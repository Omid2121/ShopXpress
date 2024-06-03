using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Bll.DTOs;

public class LoginDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(30, ErrorMessage = "Password is limited to {2} to {1} charachters.", MinimumLength= 8)]
    public string Password { get; set; }
}

public class CreateUserDTO : LoginDTO
{
    [Required]
    [DataType(DataType.Text)]
    [StringLength(40, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [StringLength(40, MinimumLength = 3)]
    public string LastName { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [Required]
    public string Address { get; set; }
}

public class UserDTO
{
    public string Id { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [StringLength(40, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [StringLength(40, MinimumLength = 3)]
    public string LastName { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [Required]
    public string Address { get; set; }
    public Guid CartId { get; set; }
    public CartDTO Cart { get; set; }
    public virtual ICollection<OrderDTO>? Orders { get; set; }
}

public class UpdateUserDTO
{
    [Required]
    [DataType(DataType.Text)]
    [StringLength(40, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [StringLength(40, MinimumLength = 3)]
    public string LastName { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [Required]
    public string Address { get; set; }
}

public class DeleteUserDTO : LoginDTO
{
}
