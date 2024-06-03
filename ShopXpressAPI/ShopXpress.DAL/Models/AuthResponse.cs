using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Models;

public class AuthResponse
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
}
