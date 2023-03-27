using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using TTInstanceManagement;
using TTStorageManager.Security;

namespace Infrastructure.Services
{
    public class AtlasAccountService : IAccountService
    {
        private readonly ITokenStoreService _tokenStoreService;

        public AtlasAccountService(ITokenStoreService tokenStoreService)
        {
            _tokenStoreService = tokenStoreService;
        }

        public Task<ClaimsIdentity> GetIdentity(string userName, string password)
        {
            var result = TTUser.CheckAuthenticate(userName, password);
            if (result.Item1 == AuthenticationResultEnum.PasswordOK)
            {
                var user = result.Item2;
                var atlasUser = new AtlasUser(new GenericIdentity(user.UserID.ToString(), "Custom"), new Claim[] { });
                return Task.FromResult(atlasUser as ClaimsIdentity);
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }

        public void Logout(HttpContext httpContext)
        {
            var user = httpContext?.User?.FindFirstValue(JwtRegisteredClaimNames.Sid);
            var jti = httpContext?.User?.FindFirstValue(JwtRegisteredClaimNames.Jti);
            var iat = httpContext?.User?.FindFirstValue(JwtRegisteredClaimNames.Iat);
            var allItems = new string[] { user, jti, iat };
            if (allItems.All(string.IsNullOrWhiteSpace) == false)
            {
                var tokenInfo = new AtlasTokenInfo();
                if ( Guid.TryParse(user, out Guid userID) && Guid.TryParse(jti, out Guid tokenIdentifier) )
                {
                    tokenInfo.UserId = userID;
                    tokenInfo.TokenIdentifier = tokenIdentifier;
                    // tokenInfo.IssueDate = iat;
                    _tokenStoreService.BlackListToken(tokenInfo);
                }
            } 

            var auditRecord = TTAuditRecord.NewLogoutAuditRecord();
            auditRecord.CreateInDatabase();
            
        }

    }
}
