 
using System.Security.Claims;

namespace WebApplication5.Infrastructure.Interfaces
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
