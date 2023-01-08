using FluentValidation;

namespace SunnyBlog.WebAPI.Controllers.User;

public record LoginByUsernamePasswordRequest(string UserName, string Password);
public class LoginByUserNameAndPwdRequestValidator : AbstractValidator<LoginByUsernamePasswordRequest>
{
    public LoginByUserNameAndPwdRequestValidator()
    {
        RuleFor(e => e.UserName).NotNull().NotEmpty();
        RuleFor(e => e.Password).NotNull().NotEmpty();
    }
}
