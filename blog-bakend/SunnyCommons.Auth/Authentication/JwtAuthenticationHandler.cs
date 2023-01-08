using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace SunnyCommons.Auth.Authentication
{
    public class JwtAuthenticationHandler : AuthenticationHandler<JwtAuthenticaionOptions>
    {
        public JwtAuthenticationHandler(IOptionsMonitor<JwtAuthenticaionOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authorization = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorization))
                return AuthenticateResult.Fail("");
            SecurityToken? token = null;
            ClaimsPrincipal? principal = null;
            try
            {
                principal = Options.defaultHandler.ValidateToken(authorization, Options.TokenValidationParameters, out token);
            }
            catch (Exception e)
            {
                return AuthenticateResult.Fail(e.Message);
            }
            return AuthenticateResult.Success(new AuthenticationTicket(principal, JwtAuthenticationDefault.AuthenticationScheme));
        }
    }
}