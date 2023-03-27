using Core.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AtlasUserManager : UserManager<AtlasUser>
    {
        public AtlasUserManager(IUserStore<AtlasUser> store
            , IOptions<IdentityOptions> optionsAccessor
            , IPasswordHasher<AtlasUser> passwordHasher
            , IEnumerable<IUserValidator<AtlasUser>> userValidators
            , IEnumerable<IPasswordValidator<AtlasUser>> passwordValidators
            , ILookupNormalizer keyNormalizer
            , IdentityErrorDescriber errors
            , IServiceProvider services
            , ILogger<UserManager<AtlasUser>> logger)
        : base(
            store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
            services, logger)
        {
        }

        public override Task<bool> IsInRoleAsync(AtlasUser user, string role)
        {
            return base.IsInRoleAsync(user, role);
        }

        public override bool SupportsUserRole => true;
    }
}
