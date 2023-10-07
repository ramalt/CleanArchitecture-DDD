
using FluentValidation;

namespace DinnerApp.Application.Menu.Command.CreateMenu;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(m => m.Name).NotEmpty().MaximumLength(255);
        RuleFor(m => m.Description).NotEmpty().MaximumLength(255);
        RuleFor(m => m.Sections).NotEmpty();
    }

}
