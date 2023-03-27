using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AtlasClaimsPrincipalFactory : IUserClaimsPrincipalFactory<AtlasUser>
    {
        public Task<ClaimsPrincipal> CreateAsync(AtlasUser user)
        {
            var principal = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(user.UserId.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, user.UserId.ToString())
                    }));
            return Task.FromResult(principal);
        }
    }
}
