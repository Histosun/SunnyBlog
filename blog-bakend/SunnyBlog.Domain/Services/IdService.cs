using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SunnyBlog.Domain.Entities;
using SunnyCommons.Auth.Token;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace SunnyBlog.Domain.Services
{
    public class IdService
    {
        private readonly IIdRepository repository;
        private readonly ITokenService tokenService;
        private readonly IOptions<JWTOptions> optJWT;
        public IdService(IIdRepository repository, ITokenService tokenService, IOptions<JWTOptions> optJWT)
        {
            this.repository = repository;
            this.tokenService = tokenService;
            this.optJWT = optJWT;
        }

        public async Task<(SignInResult Result, string? Token)> LoginByUserNameAndPwdAsync(string userName, string password)
        {
            User user = await repository.FindByNameAsync(userName);
            if (user == null)
            {
                return (SignInResult.Failed, null);
            }
            if (!await repository.CheckUserPasswordAsync(user, password))
            {
                return (SignInResult.Failed, null);
            }
            string token = await BuildToken(user);
            return (SignInResult.Success, token);
        }

        public async Task<IdentityResult> SignUpByUserNameAndPwdAsync(string userName, string password)
        {
            var user = new User(userName);
            IdentityResult result = await repository.CreateUserAsync(user, password);
            return result;
        }

        private async Task<string> BuildToken(User user)
        {
            var roles = await repository.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return tokenService.BuildToken(claims, optJWT.Value);
        }
    }
}
