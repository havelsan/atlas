using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Core.Security
{
    public class AtlasRoleAuthorizationRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> RequiredRoles { get; }

        public AtlasRoleAuthorizationRequirement(IEnumerable<string> requiredRoles)
        {
            RequiredRoles = requiredRoles;
        }
    }

}
