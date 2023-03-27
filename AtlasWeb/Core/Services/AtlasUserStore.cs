using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using TTStorageManager.Security;

namespace Core.Services
{
    public class AtlasUserStore : IUserStore<AtlasUser>
    {

        private TTUtils.IActiveUserService _activeUserService;

        public AtlasUserStore(TTUtils.IActiveUserService activeUserService)
        {
            this._activeUserService = activeUserService;
        }

        // Kullanıcı oluşturma desteklenmeyecek
        public Task<IdentityResult> CreateAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        // Kullanıcı silme desteklenmeyecek
        public Task<IdentityResult> DeleteAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {

        }

        public AtlasUser TranslateTTUserToAtlasUser(TTUser user)
        {
            if (user == null)
                return null as AtlasUser;

            var atlasUser = new AtlasUser();
            atlasUser.UserId = user.UserID;
            atlasUser.UserName = user.Name;
            return atlasUser;
        }

        public Task<AtlasUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var user = _activeUserService.GetUserByID(userId) as TTUser;
            var atlasUser = TranslateTTUserToAtlasUser(user);
            return Task.FromResult(atlasUser);
        }

        public Task<AtlasUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = _activeUserService.GetUserByName(normalizedUserName) as TTUser;
            var atlasUser = TranslateTTUserToAtlasUser(user);
            return Task.FromResult(atlasUser);
        }

        public Task<string> GetNormalizedUserNameAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name.ToUpperInvariant());
        }

        public Task<string> GetUserIdAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserId.ToString());
        }

        public Task<string> GetUserNameAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        public Task SetNormalizedUserNameAsync(AtlasUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task SetUserNameAsync(AtlasUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        // Kullanıcı güncelleme desteklenmeyecek
        public Task<IdentityResult> UpdateAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
