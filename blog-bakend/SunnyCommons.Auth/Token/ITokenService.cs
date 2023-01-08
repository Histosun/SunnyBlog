using System.Security.Claims;

namespace SunnyCommons.Auth.Token
{
    public interface ITokenService
    {
        string BuildToken(IEnumerable<Claim> claims, JWTOptions options);
    }
}
