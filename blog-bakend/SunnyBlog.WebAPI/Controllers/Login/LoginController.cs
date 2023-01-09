using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SunnyBlog.Domain;
using SunnyBlog.Domain.Services;
using SunnyBlog.WebAPI.Controllers.User;
using System.Net;

namespace SunnyBlog.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IdService idService;
        private readonly IMemoryCache memoryCache;
        public LoginController(IdService idService, ICategoryRepository categoryRepository, IMemoryCache memoryCache)
        {
            this.idService = idService;
            this.memoryCache = memoryCache;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResult>> LoginByUsernamePasswordAsync(LoginByUserNameAndPwdRequest request)
        {
            (var result, var token)=await idService.LoginByUserNameAndPwdAsync(request.UserName, request.Password);
            if (result.Succeeded)
                return new LoginResult(request.UserName, token);
            return StatusCode((int)HttpStatusCode.BadRequest, "login failed");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string?>> SignUpByUsernamePasswordAsync(LoginByUserNameAndPwdRequest request)
        {
            var result = await idService.SignUpByUserNameAndPwdAsync(request.UserName, request.Password);
            if (result.Succeeded)
                return "Account created";
            return StatusCode((int)HttpStatusCode.BadRequest, result.Errors);
        }
    }
}