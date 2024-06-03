using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Models;

public class Error
{
    public int StatusCode { get; set; }
    public required string Message { get; set; }
    public override string ToString() => JsonConvert.SerializeObject(this);
}
