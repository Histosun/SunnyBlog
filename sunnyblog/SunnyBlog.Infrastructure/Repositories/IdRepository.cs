using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SunnyBlog.Domain;
using SunnyBlog.Domain.Entities;

namespace SunnyBlog.Infrastructure.Repositories
{
    public class IdRepository : IIdRepository
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public IdRepository(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return userManager.CreateAsync(user, password);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return userManager.FindByNameAsync(userName);
        }

        public Task<bool> CheckUserPasswordAsync(User user,string password)
        {
            return userManager.CheckPasswordAsync(user, password);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return userManager.GetRolesAsync(user);
        }
    }
}
