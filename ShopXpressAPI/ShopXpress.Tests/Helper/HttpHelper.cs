using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Tests.Helper
{
    internal class HttpHelper
    {
        internal static class Urls
        {
            internal const string BaseUrl = "http://localhost:5000";
            internal const string Carts = "/api/carts";
            internal const string Orders = "/api/orders";
            internal const string Categories = "/api/categories";
            internal const string Products  = "/api/products";
        }
    }
}
