using FluentValidation;

namespace HannahAI.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.FullName)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Username)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(v => v.Email)
            .MaximumLength(256)
            .NotEmpty()
            .EmailAddress();

        RuleFor(v => v.Password)
            .MinimumLength(6)
            .NotEmpty();
    }
}
