using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IAccountService
    {
        Task<ClaimsIdentity> GetIdentity(string userName, string password);
        void Logout(HttpContext httpContext);
    }
}
