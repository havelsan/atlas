using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AtlasUserClaimStore : IUserClaimStore<AtlasUser>
    {
        public Task AddClaimsAsync(AtlasUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<IdentityResult> CreateAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<IdentityResult> DeleteAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            throw new NotSupportedException();
        }

        public Task<AtlasUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<AtlasUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<IList<Claim>> GetClaimsAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetNormalizedUserNameAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetUserIdAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetUserNameAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<IList<AtlasUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task RemoveClaimsAsync(AtlasUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task ReplaceClaimAsync(AtlasUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task SetNormalizedUserNameAsync(AtlasUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task SetUserNameAsync(AtlasUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<IdentityResult> UpdateAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
