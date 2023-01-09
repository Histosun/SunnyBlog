using FluentValidation;

namespace SunnyBlog.WebAPI.Controllers.User;

public record LoginResult(string UserName, string Token);
