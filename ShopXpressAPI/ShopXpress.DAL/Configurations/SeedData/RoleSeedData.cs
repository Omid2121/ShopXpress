using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.SeedData;

public class RoleSeedData
{
    public static List<IdentityRole> Roles()
    {
        return new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole
            {
                Name = "Consumer",
                NormalizedName = "CONSUMER"
            }
        };
    }
}
