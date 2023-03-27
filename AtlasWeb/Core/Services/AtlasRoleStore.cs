using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTStorageManager.Security;

namespace Core.Services
{
    public class AtlasRoleStore : IRoleStore<TTRole>
    {
        // Bu servis üzerinden rol oluşturma desteklenmiyor
        public Task<IdentityResult> CreateAsync(TTRole role, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        // Bu servis üzerinden rol silme desteklenmiyor
        public Task<IdentityResult> DeleteAsync(TTRole role, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            
        }

        public Task<TTRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var guidRoleId = Guid.Parse(roleId);
            if ( TTObjectDefManager.Instance.AllRoles.TryGetValue(guidRoleId, out TTRole role))
            {
                return  Task.FromResult(role);
            }
            return Task.FromResult(null as TTRole);
        }

        public Task<TTRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            if (TTObjectDefManager.Instance.AllRoles.TryGetValue(normalizedRoleName, out TTRole role))
            {
                return Task.FromResult(role);
            }
            return Task.FromResult(null as TTRole);
        }

        public Task<string> GetNormalizedRoleNameAsync(TTRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name.ToUpperInvariant());
        }

        public Task<string> GetRoleIdAsync(TTRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.ID.ToString());
        }

        public Task<string> GetRoleNameAsync(TTRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(TTRole role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task SetRoleNameAsync(TTRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<IdentityResult> UpdateAsync(TTRole role, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
