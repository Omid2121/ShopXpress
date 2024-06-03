using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Tests.TestServices
{
    public class TestAuthorizationService : DefaultAuthorizationService
    {
        public TestAuthorizationService(IAuthorizationPolicyProvider policyProvider,
            IAuthorizationHandlerProvider handlers, ILogger<DefaultAuthorizationService> logger,
            IAuthorizationHandlerContextFactory contextFactory, IAuthorizationEvaluator evaluator,
            IOptions<AuthorizationOptions> options)
            : base(policyProvider, handlers, logger, contextFactory, evaluator, options)
        {}

        public override Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object? resource, IEnumerable<IAuthorizationRequirement> requirements)
        {
            return Task.FromResult(AuthorizationResult.Success());
        }
    }
}
