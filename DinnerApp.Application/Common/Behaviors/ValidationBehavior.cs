using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Services.Authentication;
using DinnerApp.Domain.Entities;
using FluentValidation;
using MediatR;

namespace DinnerApp.Application.Common.Behaviors;

public class ValidationBehavior : IPipelineBehavior<RegisterCommand, AuthResult>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidationBehavior(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<AuthResult> Handle(RegisterCommand request,
                                   RequestHandlerDelegate<AuthResult> next,
                                   CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

        // errorMessages listesini döndürebilirsiniz
        return new AuthResult(default(User), "", errorMessages);



    }
}