using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTStorageManager.Security;

namespace Core.Security
{
    public class AtlasRequiredRolesAttribute : TypeFilterAttribute
    {
        public AtlasRequiredRolesAttribute(params string[] roles)
            : base(typeof(AtlasRequireRoleAttributeImpl))
        {
            Arguments = new[] { new AtlasRoleAuthorizationRequirement(roles) };
        }

        private class AtlasRequireRoleAttributeImpl : Attribute, IAsyncResourceFilter
        {
            private readonly AtlasRoleAuthorizationRequirement _requiredRoles;
            private readonly TTUtils.IActiveUserService _activeUserService;

            public AtlasRequireRoleAttributeImpl(AtlasRoleAuthorizationRequirement requiredRoles, TTUtils.IActiveUserService activeUserService)
            {
                _activeUserService = activeUserService;
                _requiredRoles = requiredRoles;
            }

            public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
            {
                var currentUser = _activeUserService.CurrentUser as TTUser;
                if (currentUser.IsSuperUser)
                {
                    await next();
                }
                else
                {
                    var isUserHasRole = false;
                    foreach (var requiredRole in _requiredRoles.RequiredRoles)
                    {
                        if (Guid.TryParse(requiredRole, out Guid requiredRoleGuid))
                        {
                            if (currentUser.HasRole(requiredRoleGuid) == true)
                            {
                                isUserHasRole = true;
                            }
                        }
                    }

                    if (isUserHasRole == false)
                    {
                        context.Result = new ForbidResult();
                    }
                    else
                    {
                        await next();
                    }
                }
            }
        }
    }
}
