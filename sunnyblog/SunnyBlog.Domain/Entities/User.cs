using Microsoft.AspNetCore.Identity;

namespace SunnyBlog.Domain.Entities
{
    public class User : IdentityUser<long>
    {
        public User() { }
        public User(string userName) : base(userName) { }
    }
}
