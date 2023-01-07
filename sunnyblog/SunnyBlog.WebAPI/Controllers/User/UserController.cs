using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SunnyBlog.Domain;
using SunnyBlog.WebAPI.Controllers.User;

namespace SunnyBlog.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IIdRepository UserRepository;
        private readonly IMemoryCache MemoryCache;
        public UserController(IIdRepository userRepository, ICategoryRepository categoryRepository, IMemoryCache memoryCache)
        {
            UserRepository = userRepository;
            MemoryCache = memoryCache;
        }
        [HttpPost]
        public ActionResult<LoginResult> LoginByUsernamePassword(LoginByUsernamePasswordRequest request)
        {
            
            return null;
        }
    }
}