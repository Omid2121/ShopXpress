using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Tests.TestServices
{
    public class TestAuthenticationService : AuthenticationService
    {
        public TestAuthenticationService(IAuthenticationSchemeProvider schemes,
            IAuthenticationHandlerProvider handlers, IClaimsTransformation transform,
            IOptions<AuthenticationOptions> options)
            : base(schemes, handlers, transform, options)
        {}

        public override Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string? scheme)
        {
            Claim[] claims = { new Claim(ClaimTypes.Name, "TestUser") };
            ClaimsIdentity identity = new(claims, "Test");
            ClaimsPrincipal principal = new(identity);
            AuthenticationTicket ticket = new(principal, "TestScheme");

            AuthenticateResult result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}
