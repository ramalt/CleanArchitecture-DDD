using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DinnerApp.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var exceptionObjectResult = new ProblemDetails
        { 
            Title = exception.Message,
            Status = 500,
            
        };

        context.Result = new ObjectResult(exceptionObjectResult);

        context.ExceptionHandled = true;
    }
}
