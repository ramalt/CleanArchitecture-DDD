using DinnerApp.Application.Services.Authentication;

using FluentValidation;
using MediatR;

namespace DinnerApp.Application.Common.Behaviors;

public class ValidationBehavior<TRequset, TResponse> : IPipelineBehavior<TRequset, TResponse> where TRequset : IRequest<TResponse> where TResponse : AuthResult
{
    private readonly IValidator<TRequset> _validator;

    public ValidationBehavior(IValidator<TRequset> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequset request,
                                   RequestHandlerDelegate<TResponse> next,
                                   CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            throw new Exception(errorMessages.ToString());
        }
            return await next();


        // return (dynamic)new AuthResult(default, "");



    }
}