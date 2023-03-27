using Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using TTStorageManager.Security;

namespace Infrastructure.Services
{
    public class AtlasActiveUserService : TTUtils.IActiveUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IActionContextAccessor _actionContextAccessor;

        private static readonly System.Collections.Concurrent.ConcurrentDictionary<Guid, TTUser> _userCacheByID = new ConcurrentDictionary<Guid, TTUser>();
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, TTUser> _userCacheByName = new ConcurrentDictionary<string, TTUser>();

        static readonly AsyncLocal<HttpContext> _httpContextCurrent = new AsyncLocal<HttpContext>();

        public AtlasActiveUserService(IHttpContextAccessor httpContextAccessor, IActionContextAccessor actionContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._actionContextAccessor = actionContextAccessor;
        }

        private TTUser GetActiveUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                user = _actionContextAccessor.ActionContext?.HttpContext?.User;
                if (user == null)
                {
                    var contextAccessor = DependencyResolver.Current.HttpContextAccessor;
                    user = contextAccessor.HttpContext?.User;
                    if (user == null)
                        return null;
                }
            }

            var userIDKey = user.FindFirstValue(JwtRegisteredClaimNames.Sid);
            if (string.IsNullOrWhiteSpace(userIDKey))
                return null;
            return GetUserByID(userIDKey) as TTUser;
        }


        public void AddUserToCache(object user)
        {
            var ttUser = user as TTUser;
            if (ttUser != null)
            {
                var userRoles = ttUser.Roles;
                //TODO: 5 dakika expire parametrik yapılacak
                _userCacheByID[ttUser.UserID] = ttUser;
                _userCacheByName[ttUser.Name.ToUpperInvariant()] = ttUser;
            }
        }

        public object GetUserByID(string userIDKey)
        {
            if (Guid.TryParse(userIDKey, out Guid userID))
            {
                if (_userCacheByID.TryGetValue(userID, out TTUser cachedUser))
                {
                    return cachedUser;
                }

                var user = TTUser.GetUser(userID);
                AddUserToCache(user);
                return user;
            }

            return null;
        }

        public object GetUserByName(string userName)
        {
            if (_userCacheByName.TryGetValue(userName, out TTUser cachedUser))
            {
                return cachedUser;
            }

            var user = TTUser.GetUser(userName);
            AddUserToCache(user);
            return user;
        }

        public object CurrentUser
        {
            get
            {
                return GetActiveUser();
            }
        }

        public string UserName
        {
            get
            {
                return GetActiveUser()?.Name;
            }
        }

        public string SessionId
        {
            get
            {
                var accessToken = GetAccessToken();
                if (string.IsNullOrWhiteSpace(accessToken) == false)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadToken(accessToken) as JwtSecurityToken;
                    return jwt.Id;
                }
                return string.Empty;
            }
        }

        public string MachineName
        {
            get
            {
                var ipAddress = WorkstationIpAddress;
                return System.Net.Dns.GetHostEntry(ipAddress)?.HostName;
            }
        }

        public IEnumerable<Guid> ActiveUsers
        {
            get
            {
                return _userCacheByID.Keys.ToList();
            }
        }

        public string WorkstationIpAddress
        {
            get
            {
                return _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            }
        }

        public string CurrentCulture
        {
            get
            {
                return _actionContextAccessor?.ActionContext?.HttpContext?.Request?.Headers?.GetCurrentCulture();
            }
        }

        public string GetAccessToken()
        {
            string authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorization))
            {
                return string.Empty;
            }

            var token = authorization.Substring("Bearer ".Length).Trim();

            return token;
        }
    }
}
