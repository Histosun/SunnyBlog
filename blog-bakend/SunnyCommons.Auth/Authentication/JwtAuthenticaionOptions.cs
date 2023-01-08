using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace SunnyCommons.Auth.Authentication
{
    public class JwtAuthenticaionOptions : AuthenticationSchemeOptions
    {
        public readonly JwtSecurityTokenHandler defaultHandler;
        public TokenValidationParameters TokenValidationParameters { get; set; } = new TokenValidationParameters();

        public JwtAuthenticaionOptions()
        {
            defaultHandler = new();
        }
    }
}
