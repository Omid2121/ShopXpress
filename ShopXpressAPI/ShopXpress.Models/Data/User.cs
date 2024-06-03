using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Models.Data;

public class User : IdentityUser
{
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    
    public  Guid CartId { get; set; }
    public  Cart Cart { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}
