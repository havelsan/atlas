using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ITokenValidatorService
    {
        Task ValidateAsync(TokenValidatedContext context);
    }

}
