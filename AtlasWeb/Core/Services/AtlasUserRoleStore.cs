using Core.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTStorageManager.Security;

namespace Core.Services
{
    public class AtlasUserRoleStore : IUserRoleStore<AtlasUser>
    {
        private TTUtils.IActiveUserService _activeUserService;
        private IUserStore<AtlasUser> _userStore;
        private IRoleStore<TTRole> _roleStore;

        public AtlasUserRoleStore(TTUtils.IActiveUserService activeUserService, IUserStore<AtlasUser> userStore, IRoleStore<TTRole> roleStore)
        {
            this._activeUserService = activeUserService;
            this._userStore = userStore;
            this._roleStore = roleStore;
        }

        public Task AddToRoleAsync(AtlasUser user, string roleName, CancellationToken cancellationToken)
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
        }

        public Task<AtlasUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return _userStore.FindByIdAsync(userId, cancellationToken);
        }

        public Task<AtlasUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return _userStore.FindByNameAsync(normalizedUserName, cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            return _userStore.GetNormalizedUserNameAsync(user, cancellationToken);
        }

        public Task<IList<string>> GetRolesAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetUserIdAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            return _userStore.GetUserIdAsync(user, cancellationToken);
        }

        public Task<string> GetUserNameAsync(AtlasUser user, CancellationToken cancellationToken)
        {
            return _userStore.GetUserNameAsync(user, cancellationToken);
        }

        public Task<IList<AtlasUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<bool> IsInRoleAsync(AtlasUser user, string roleName, CancellationToken cancellationToken)
        {
            var userHasRole = false;
            var ttUser = _activeUserService.GetUserByID(user.UserId.ToString()) as TTUser;
            if (ttUser != null)
            {
                if (TTObjectDefManager.Instance.AllRoles.TryGetValue(roleName, out TTRole role))
                {
                    userHasRole = ttUser.HasRole(role.ID);
                }
            }

            return Task.FromResult(userHasRole);
        }

        public Task RemoveFromRoleAsync(AtlasUser user, string roleName, CancellationToken cancellationToken)
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
