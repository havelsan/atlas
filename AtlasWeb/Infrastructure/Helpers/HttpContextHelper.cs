using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Helpers
{
    public static class HttpContextHelper
    {
        public static string GetUserIDKey(this HttpContext httpContext)
        {
            var userIDKey = httpContext.User?.FindFirstValue(JwtRegisteredClaimNames.Sid);
            return userIDKey;
        }

        public static string GetClientWorkstationName(this HttpContext httpContext)
        {
            var remoteIpAddress = httpContext.Connection.RemoteIpAddress;

            try
            {
                string[] computerName = System.Net.Dns.GetHostEntry(remoteIpAddress).HostName.Split(new char[] { '.' });
                return computerName[0].ToString();
            }
            catch { }

            return remoteIpAddress.ToString();
        }

        public static string GetRemoteIpAddress(this HttpContext httpContext)
        {
            var userHostAddress = httpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            if (userHostAddress != null)
            {
                return userHostAddress.ToString();
            }

            return string.Empty;
        }
    }
}