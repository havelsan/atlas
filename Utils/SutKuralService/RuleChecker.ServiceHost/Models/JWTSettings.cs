using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace RuleChecker.ServiceHost.Models
{
    public class JWTSettings
    {
        public SigningCredentials SigningCredentials { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan ClockSkew { get; set; }
    }
}
