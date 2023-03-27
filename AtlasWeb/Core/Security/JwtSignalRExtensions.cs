using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Security
{
    public static class JwtSignalRExtensions
    {
        private static readonly String AUTH_QUERY_STRING_KEY = "authtoken";

        public static void UseJwtSignalRAuthentication(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (string.IsNullOrWhiteSpace(context.Request.Headers["Authorization"]))
                {
                    try
                    {
                        if (context.Request.QueryString.HasValue)
                        {

                            var query = from field in context.Request.QueryString.Value.Split('&')
                                        let leftPart = field.Split('=')?.FirstOrDefault()
                                        let rightPart = field.Split('=')?.LastOrDefault()
                                        where leftPart == AUTH_QUERY_STRING_KEY
                                        select rightPart;

                            var token = query.FirstOrDefault();

                            if (!string.IsNullOrWhiteSpace(token))
                            {
                                context.Request.Headers.Add("Authorization", new[] { $"Bearer {token}" });
                            }

                        }

                    }
                    catch
                    {
                        // if multiple headers it may throw an error.  Ignore both.
                    }
                }
                await next.Invoke();
            });

        }
    }
}
