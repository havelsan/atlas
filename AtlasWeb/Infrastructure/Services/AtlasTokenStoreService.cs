using Infrastructure.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class AtlasTokenStoreService : ITokenStoreService
    {
        public ConcurrentDictionary<Guid, AtlasTokenInfo> _tokenStore;
        public ConcurrentDictionary<Guid, AtlasTokenInfo> _tokenBlackList;

        public AtlasTokenStoreService()
        {
            _tokenStore = new ConcurrentDictionary<Guid, AtlasTokenInfo>();
            _tokenBlackList = new ConcurrentDictionary<Guid, AtlasTokenInfo>();
        }

        public void BlackListToken(AtlasTokenInfo tokenInfo)
        {
            if (_tokenBlackList.ContainsKey(tokenInfo.TokenIdentifier) == false)
            {
                _tokenBlackList.TryAdd(tokenInfo.TokenIdentifier, tokenInfo);
            }
        }

        public void AddIssuedToken(AtlasTokenInfo tokenInfo)
        {
            _tokenStore.TryAdd(tokenInfo.TokenIdentifier, tokenInfo);
            BlackListPreviousTokens(tokenInfo);
        }

        private void BlackListPreviousTokens(AtlasTokenInfo tokenInfo)
        {
            var query = from token in _tokenStore.Values
                        where token.TokenIdentifier != tokenInfo.TokenIdentifier
                        && token.UserId == tokenInfo.UserId
                        select token;
            if (query.Any())
            {
                foreach (var tokenInfoOther in query)
                {
                    if (_tokenBlackList.ContainsKey(tokenInfoOther.TokenIdentifier) == false)
                    {
                        _tokenBlackList.TryAdd(tokenInfoOther.TokenIdentifier, tokenInfoOther);
                    }
                }
            }
        }

        public bool IsTokenBlackListed(Guid tokenIdentifier)
        {
            var tokenIsBlackListed = _tokenBlackList.ContainsKey(tokenIdentifier);
            return tokenIsBlackListed;
        }
    }
}
