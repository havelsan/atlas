using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Filters
{
    public class AtlasAuthorizeFilter : AuthorizeFilter
    {
        private static readonly PathString ApiPathString = new PathString("/api");
        private static readonly PathString AuthApiPathString = new PathString("/api/authenticate");
        

        public AtlasAuthorizeFilter(AuthorizationPolicy policy)
            : base(policy)
        {
        }

        public AtlasAuthorizeFilter(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizeData> authorizeData)
            : base(policyProvider, authorizeData)
        {
        }

        public AtlasAuthorizeFilter(IEnumerable<IAuthorizeData> authorizeData) 
            : base(authorizeData)
        {
        }

        public AtlasAuthorizeFilter(string policy)
            : base(policy)
        {
        }

        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            var isApiRequest = context.HttpContext.Request.Path.StartsWithSegments(ApiPathString, StringComparison.InvariantCultureIgnoreCase);

            if ( context.HttpContext.Request.Path.Equals(AuthApiPathString) == false )
            {
                if (isApiRequest == true)
                {
                    return base.OnAuthorizationAsync(context);
                }
            }

            return Task.CompletedTask;
        }
    }
}
