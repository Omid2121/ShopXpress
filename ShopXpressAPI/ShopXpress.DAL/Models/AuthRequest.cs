using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Models;

public class AuthRequest
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
