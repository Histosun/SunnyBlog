using Microsoft.AspNetCore.Identity;
using SunnyBlog.Domain.Entities;

namespace SunnyBlog.Domain
{
    public interface IIdRepository
    {
        Task<User> FindByNameAsync(string userName);

        Task<bool> CheckUserPasswordAsync(User user, string password);

        Task<IList<string>> GetRolesAsync(User user);

        Task<IdentityResult> CreateUserAsync(User user, string password);
    }
}
