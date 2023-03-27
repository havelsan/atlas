using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using TTStorageManager.Security;

namespace Core.Filters
{
    public class InvoiceRoleRequirement : AuthorizationHandler<InvoiceRoleRequirement, Guid>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, InvoiceRoleRequirement requirement, Guid resource)
        {
            if (TTUser.CurrentUser.HasRole(resource) == false)
            {
                context.Fail();
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
