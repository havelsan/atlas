using Infrastructure.Models;
using System;

namespace Infrastructure.Services
{
    public interface ITokenStoreService
    {
        void AddIssuedToken(AtlasTokenInfo tokenInfo);
        void BlackListToken(AtlasTokenInfo tokenInfo);
        bool IsTokenBlackListed(Guid tokenIdentifier);
    }
}
