using Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class CustomJwtDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string algorithm;
        private readonly TokenValidationParameters validationParameters;
        private readonly JWTSettings _options;

        public CustomJwtDataFormat(string algorithm, TokenValidationParameters validationParameters, JWTSettings options)
        {
            this.algorithm = algorithm;
            this.validationParameters = validationParameters;
            this._options = options;
        }

        public AuthenticationTicket Unprotect(string protectedText)
            => Unprotect(protectedText, null);

        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = null;
            SecurityToken validToken = null;

            try
            {
                principal = handler.ValidateToken(protectedText, this.validationParameters, out validToken);
                
                var validJwt = validToken as JwtSecurityToken;

                if (validJwt == null)
                {
                    throw new ArgumentException("Invalid JWT");
                }

                if (!validJwt.Header.Alg.Equals(algorithm, StringComparison.Ordinal))
                {
                    throw new ArgumentException($"Algorithm must be '{algorithm}'");
                }

                // Additional custom validation of JWT claims here (if any)
            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }

            // Validation passed. Return a valid AuthenticationTicket:
            return new AuthenticationTicket(principal, new AuthenticationProperties(), "Cookie");
        }

        // This ISecureDataFormat implementation is decode-only
        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();
        }

        public string Protect(AuthenticationTicket data, string purpose)
        {
            if (data == null) throw new ArgumentNullException("data");

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretKey));
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(15);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_options.Issuer, _options.Audience, data.Principal.Claims, now, expires, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
