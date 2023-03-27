using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace Infrastructure.Models
{
    public class AtlasUser : ClaimsIdentity
    {
        public AtlasUser()
        {
        }

        public AtlasUser(IIdentity identity, IEnumerable<Claim> claims)
            : base(identity, claims)
        {
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserNameNormalized => UserName?.ToUpperInvariant();
        public string Email { get; set; }
        public string EmailNormalized => Email?.ToUpper();
    }

    public class AtlasRole
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleNameNormalized => RoleName?.ToUpperInvariant();
    }
}