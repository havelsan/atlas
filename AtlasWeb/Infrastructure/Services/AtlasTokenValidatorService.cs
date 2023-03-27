using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AtlasTokenValidatorService : ITokenValidatorService
    {
        private readonly ITokenStoreService _tokenStoreService;

        public AtlasTokenValidatorService(ITokenStoreService tokenStoreService)
        {
            _tokenStoreService = tokenStoreService;
        }

        public Task ValidateAsync(TokenValidatedContext context)
        {
            var securityTokenIdentifier = context.SecurityToken.Id;

            if (Guid.TryParse(securityTokenIdentifier, out Guid tokenIdentifier))
            {
                if (_tokenStoreService.IsTokenBlackListed(tokenIdentifier))
                {
                    context.Fail("This token is expired. Please login again.");
                    return Task.FromResult(0);
                }
            }

            return Task.CompletedTask;
        }
    }
}
